using Common;
using Common.ProjectHelpers;
using Model.Auth;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICourseService {
        ResponseHelper InsertOrUpdateBasicInformation(Course model);
    }
    class CourseService : ICourseService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Course> _courseRepo;
        private readonly IRepository<ApplicationRole> _roleRepo;
        private readonly IRepository<ApplicationUserRole> _userRepo;

        public CourseService(
                IDbContextScopeFactory dbContextScopeFactory,
                IRepository<Course> courseRepo,
                IRepository<ApplicationRole> roleRepo,
                IRepository<ApplicationUserRole> userRepo
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _courseRepo = courseRepo;
            _roleRepo = roleRepo;
            _userRepo = userRepo;
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
    }
}
