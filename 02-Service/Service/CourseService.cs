﻿using Common;
using Common.ProjectHelpers;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service
{
    public interface ICourseService {
        IEnumerable<CourseCard> GetAll(int categoryId = 0);
        ResponseHelper InsertOrUpdateBasicInformation(Course model);
        CourseLandingPage GetForLandingPage(int id);
        Course Get(int id);
        ResponseHelper AddImage(int id, HttpPostedFileBase file);
        ResponseHelper Purchase(int courseId, string userId);
        AnexGRIDResponde GetAll(AnexGRID grid);
        ResponseHelper ChangeStatus(int id, Enums.Status status);
    }
    class CourseService : ICourseService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<ApplicationRole> _roleRepo;
        private readonly IRepository<ApplicationUserRole> _userRepo;
        private readonly IRepository<ApplicationUser> _applicationUserRepo;
        private readonly IRepository<UsersPerCourses> _userPerCourseRepo;
        private readonly IRepository<Incomes> _incomeRepo;

        public CourseService(
                IDbContextScopeFactory dbContextScopeFactory,
                IRepository<Course> courseRepo,
                IRepository<ApplicationRole> roleRepo,
                IRepository<ApplicationUserRole> userRepo,
                IRepository<ApplicationUser> applicationUserRepo,
                IRepository<UsersPerCourses> userPerCourseRepo,
                IRepository<Incomes> incomeRepo
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _courseRepo = courseRepo;
            _roleRepo = roleRepo;
            _userRepo = userRepo;
            _applicationUserRepo = applicationUserRepo;
            _userPerCourseRepo = userPerCourseRepo;
            _incomeRepo = incomeRepo;
        }

        public Course Get(int id)
        {
            var result = new Course();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _courseRepo.Single(x => x.Id == id);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper InsertOrUpdateBasicInformation(Course model)
        {
            var rh = new ResponseHelper();
            var newRecord = false;

            try {
                using (var ctx = _dbContextScopeFactory.Create()) {
                    if (model.Id > 0)
                    {
                        var originalCourse = _courseRepo.Single(x => x.Id == model.Id);
                        originalCourse.Name = model.Name;
                        originalCourse.Description = model.Description;
                        originalCourse.Price = model.Price;
                        originalCourse.CategoryId = model.CategoryId;
                        originalCourse.Slug = Slug.Course(model.Id, model.Name);

                        _courseRepo.Update(originalCourse);
                    }
                    else {
                        newRecord = true;
                        model.AuthorId = CurrentUserHelper.Get.UserId;
                        model.Status = Enums.Status.Pending;
                        model.Image1 = "assets/images/courses/no-image.jpg";
                        model.Image2 = model.Image1;

                        var studentRole = _roleRepo.SingleOrDefault(x => x.Name == RolNames.Teacher);

                        var hasRole = _userRepo.Find(
                            x => x.UserId == model.AuthorId && x.RoleId == studentRole.Id).Any();

                        if (!hasRole) {
                            _userRepo.Insert(new ApplicationUserRole {
                                UserId = model.AuthorId, RoleId = studentRole.Id
                            });
                        }
                        _courseRepo.Insert(model);
                    }

                    ctx.SaveChanges();
                }

                if (newRecord) {
                    using (var ctx = _dbContextScopeFactory.Create()) {

                        var originalCourse = _courseRepo.Single(x => x.Id == model.Id);

                        originalCourse.Slug = Slug.Course(model.Id, model.Name);

                        _courseRepo.Update(originalCourse);

                        ctx.SaveChanges();
                    }
                }

                rh.SetResponse(true);

            } catch (Exception e) {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

        public ResponseHelper AddImage(int id, HttpPostedFileBase file)
        {
            var rh = new ResponseHelper();

            try
            {
                // Creamos la ruta
                var path = DirectoryPath.CourseImage(id);
                DirectoryPath.Create(path);

                // Ahora vamos a crear los nombres para el archivo
                var fileName = path
                               + DateTime.Now.ToString("yyyyMMddHHmmss")
                               + Path.GetExtension(file.FileName);

                // La ruta completa
                var fullPath = HttpContext.Current.Server.MapPath("~/" + fileName);

                // La ruta donde lo vamos guardar
                file.SaveAs(fullPath);

                using (var ctx = _dbContextScopeFactory.Create())
                {
                    // Obtenemos el curso
                    var originalCourse = _courseRepo.Single(x => x.Id == id);

                    // Seteamos la imagen
                    originalCourse.Image1 = fileName;
                    originalCourse.Image2 = fileName;

                    _courseRepo.Update(originalCourse);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                    rh.Result = fileName;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

        public IEnumerable<CourseCard> GetAll(int categoryId = 0)
        {
            var result = new List<CourseCard>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var courses = ctx.GetEntity<Course>();
                    var categories = ctx.GetEntity<Category>();
                    var lessons = ctx.GetEntity<LessonsPerCourse>();
                    var students = ctx.GetEntity<UsersPerCourses>();
                    var users = ctx.GetEntity<ApplicationUser>();

                    var queryStudents = (
                        from c in courses
                        from s in students.Where(x => x.CourseId == c.Id)
                        select new
                        {
                            UserId = s.UserId,
                            CourseId = c.Id
                        }
                    ).AsQueryable();

                    var query = (
                        from c in courses
                        from u in users.Where(x => x.Id == c.AuthorId)
                        from ca in categories.Where(x => x.Id == c.CategoryId)
                        where c.Status == Enums.Status.Approved
                        select new CourseCard
                        {
                            Id = c.Id,
                            CategoryId = ca.Id,
                            CategoryName = ca.Name,
                            CategoryIcon = ca.Icon,
                            Name = c.Name,
                            Slug = c.Slug,
                            Description = c.Description,
                            Image = c.Image1,
                            Instructor = (u.LastName + ", " + u.Name),
                            Price = c.Price,
                            Vote = c.Vote,
                            Students = queryStudents.Where(x => x.CourseId == c.Id).Count()
                        }
                    ).AsQueryable();

                    if (categoryId == 0)
                    {
                        query = query.OrderBy(x => Guid.NewGuid());
                    }
                    else
                    {
                        query = query.Where(x => x.CategoryId == categoryId)
                                     .OrderBy(x => Guid.NewGuid());
                    }

                    result = query.ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public CourseLandingPage GetForLandingPage(int id)
        {
            var result = new CourseLandingPage();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var courses = ctx.GetEntity<Course>();
                    var categories = ctx.GetEntity<Category>();
                    var lessons = ctx.GetEntity<LessonsPerCourse>();
                    var reviews = ctx.GetEntity<ReviewPerCourse>();
                    var students = ctx.GetEntity<UsersPerCourses>();
                    var users = ctx.GetEntity<ApplicationUser>();

                    var queryStudents = (
                        from c in courses
                        from s in students.Where(x => x.CourseId == c.Id)
                        select new
                        {
                            UserId = s.UserId,
                            CourseId = c.Id
                        }
                    ).AsQueryable();

                    var queryReviews = (
                        from r in reviews
                        from s in students.Where(x => x.CourseId == r.CourseId)
                        from u in users.Where(x => x.Id == s.UserId)
                        select new
                        {
                            r.Id,
                            r.CourseId,
                            s.UserId,
                            User = u.LastName + ", " + u.Name,
                            r.Vote,
                            r.CreatedAt,
                            r.Comment
                        }
                    ).AsQueryable();

                    var query = (
                        from c in courses
                        from u in users.Where(x => x.Id == c.AuthorId)
                        from ca in categories.Where(x => x.Id == c.CategoryId)
                        where c.Id == id
                        select new CourseLandingPage
                        {
                            Id = c.Id,
                            CategoryId = ca.Id,
                            CategoryName = ca.Name,
                            CategoryIcon = ca.Icon,
                            Name = c.Name,
                            Slug = c.Slug,
                            Description = c.Description,
                            Image = c.Image1,
                            Instructor = (u.LastName + ", " + u.Name),
                            Price = c.Price,
                            Vote = c.Vote,
                            Students = queryStudents.Where(x => x.CourseId == c.Id).Count(),
                            Status = c.Status,
                            Lessons = lessons.Where(x => x.CourseId == c.Id).OrderBy(x => x.Order).Select(y =>
                                new CourseLessonsLandingPage
                                {
                                    Id = y.Id,
                                    Name = y.Name,
                                    Video = y.Video != null && y.Video.Length > 0
                                }
                            ).ToList(),
                            Comments = queryReviews.Where(x => x.CourseId == c.Id).OrderByDescending(x => x.CreatedAt).Take(10).Select(y =>
                                new CourseCommentsLandingPage
                                {
                                    Id = y.Id,
                                    User = y.User,
                                    Comment = y.Comment,
                                    Date = y.CreatedAt,
                                    Vote = y.Vote
                                }
                            ).ToList(),
                            TotalComments = queryReviews.Count()
                        }
                    ).AsQueryable();

                    var xxxx = queryReviews.Count();

                    result = query.SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public ResponseHelper Purchase(int courseId, string userId)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateWithTransaction(
                    IsolationLevel.Serializable
                ))
                {
                    var user = _applicationUserRepo.Single(x => x.Id == userId);
                    var course = _courseRepo.Single(x => x.Id == courseId);

                    var hasTaken = _userPerCourseRepo.Find(x =>
                        x.UserId == userId
                        && x.CourseId == courseId
                    ).Any();

                    // Si el curso ya fue tomado no hacemos nada
                    if (hasTaken)
                    {
                        rh.SetResponse(false, "El curso ya ha sido tomado por este alumno");
                    }
                    // Si el precio del curso es mayor a los créditos actuales
                    else if (Convert.ToDecimal(course.Price) > user.Credit)
                    {
                        rh.SetResponse(false, "Usted no cuenta con los créditos necesarios para adquirir el curso");
                    }
                    else
                    {
                        var hasPriorCourses = _userPerCourseRepo.Find(x =>
                            x.UserId == userId
                        ).Any();

                        // Verificamos si es la primera vez que compra el curso. Si fuera así, asignamos el rol de estudiante
                        if (!hasPriorCourses)
                        {
                            var role = _roleRepo.Single(x =>
                                x.Name == RolNames.Student
                            );

                            _userRepo.Insert(new ApplicationUserRole
                            {
                                UserId = userId,
                                RoleId = role.Id
                            });
                        }

                        // Asignamos un curso a un usuario
                        _userPerCourseRepo.Insert(new UsersPerCourses
                        {
                            UserId = userId,
                            CourseId = courseId
                        });

                        // Actualizamos el crédito del usuario
                        user.Credit = user.Credit - Convert.ToDecimal(course.Price);
                        _applicationUserRepo.Update(user);

                        var incomes = new List<Incomes>
                        {
                            // Ingreso total
                            new Incomes {
                                EntityType = Enums.EntityType.Courses,
                                EntityID = course.Id,
                                IncomeType = Enums.IncomeType.Total,
                                Total = Convert.ToDecimal(course.Price)
                            },

                            // Ingreso profesor
                            new Incomes
                            {
                                EntityType = Enums.EntityType.Courses,
                                EntityID = course.Id,
                                IncomeType = Enums.IncomeType.TeacherTotal,
                                Total = (Convert.ToDecimal(course.Price)) * (Convert.ToDecimal(Parameters.TeacherComission) / 100)
                            },

                            // Ingreso para la empresa
                            new Incomes
                            {
                                EntityType = Enums.EntityType.Courses,
                                EntityID = course.Id,
                                IncomeType = Enums.IncomeType.CompanyTotal,
                                Total = (Convert.ToDecimal(course.Price)) * (Convert.ToDecimal(Parameters.SalesCommission) / 100)
                            }
                        };

                        _incomeRepo.Insert(incomes);

                        rh.SetResponse(true);
                    }

                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }

        public AnexGRIDResponde GetAll(AnexGRID grid)
        {
            grid.Inicializar();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    var courses = ctx.GetEntity<Course>();
                    var categories = ctx.GetEntity<Category>();
                    var lessons = ctx.GetEntity<LessonsPerCourse>();
                    var students = ctx.GetEntity<UsersPerCourses>();
                    var users = ctx.GetEntity<ApplicationUser>();

                    var queryStudents = (
                        from c in courses
                        from s in students.Where(x => x.CourseId == c.Id)
                        select new
                        {
                            UserId = s.UserId,
                            CourseId = c.Id
                        }
                    ).AsQueryable();

                    var query = (
                        from c in courses
                        from u in users.Where(x => x.Id == c.AuthorId)
                        select new CourseForGridView
                        {
                            Id = c.Id,
                            Instructor = (u.LastName + ", " + u.Name),
                            Name = c.Name,
                            Lessons = lessons.Where(x => x.CourseId == c.Id).Count(),
                            Students = queryStudents.Where(x => x.CourseId == c.Id).Count(),
                            Status = c.Status
                        }
                    ).AsQueryable();

                    // Order by
                    if (grid.columna == "Name")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Name)
                                                             : query.OrderBy(x => x.Name);
                    }

                    var data = query.Skip(grid.pagina)
                                    .Take(grid.limite)
                                    .ToList();

                    var total = query.Count();

                    grid.SetData(data, total);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return grid.responde();
        }

        public ResponseHelper ChangeStatus(int id, Enums.Status status)
        {
            var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {
                    var originalEntry = _courseRepo.Single(x => x.Id == id);
                    originalEntry.Status = status;

                    _courseRepo.Update(originalEntry);

                    ctx.SaveChanges();
                    rh.SetResponse(true);
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
                rh.SetResponse(false, e.Message);
            }

            return rh;
        }
    }
}
