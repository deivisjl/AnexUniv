using Common;
using Common.ProjectHelpers;
using Microsoft.Owin.Logging;
using Model.Auth;
using Model.Custom;
using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.DbContextScope.Extensions;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICategoryService
    {
        ResponseHelper InsertOrUpdate(Category model);
        AnexGRIDResponde GetAll(AnexGRID grid);
        Category Get(int id);
    }

    public class CategoryService : ICategoryService
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Category> _categoryRepo;

        public CategoryService(
            IDbContextScopeFactory dbContextScopeFactory, 
            IRepository<Category> categoryRepo) {

            this._dbContextScopeFactory = dbContextScopeFactory;
            this._categoryRepo = categoryRepo;

        }

        public ResponseHelper InsertOrUpdate(Category model) {

            var rh = new ResponseHelper();
            var newRecord = false;
            try {

                using (var ctx = _dbContextScopeFactory.Create()) {

                    if (model.Id > 0)
                    {
                        var originalCategory = _categoryRepo.Single(x => x.Id == model.Id);

                        originalCategory.Name = model.Name;
                        originalCategory.Icon = model.Icon;
                        originalCategory.Slug = Slug.Category(model.Id, model.Name);

                        _categoryRepo.Update(originalCategory);
                    }
                    else {

                        newRecord = true;

                        _categoryRepo.Insert(model);
                    }
                    
                    ctx.SaveChanges();

                }

                if (newRecord)
                {

                    using (var ctx = _dbContextScopeFactory.Create())
                    {

                        var originalCategory = _categoryRepo.Single(x => x.Id == model.Id);

                        originalCategory.Slug = Slug.Category(model.Id, model.Name);

                        _categoryRepo.Update(originalCategory);

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

        public Category Get(int id)
        {
            var result = new Category();

            try {

                using (var ctx = _dbContextScopeFactory.CreateReadOnly()) {

                    result = _categoryRepo.SingleOrDefault(x => x.Id == id);
                }
            } catch (Exception e) {

                logger.Error(e.Message);
            }

            return result;
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
                    var students = ctx.GetEntity<UsersPerCourses>();

                    var queryStudents = (
                        from c in courses
                        from s in students.Where(x => x.CourseId == c.Id)
                        select new
                        {
                            UserId = s.UserId,
                            CategoryId = c.CategoryId
                        }
                    ).AsQueryable();

                    var query = (
                        from c in categories
                        select new CategoryForGridView
                        {
                            Id = c.Id,
                            Icon = c.Icon,
                            Name = c.Name,
                            Courses = courses.Where(x => x.CategoryId == c.Id).Count(),
                            Students = queryStudents.Where(x => x.CategoryId == c.Id).Count()
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
    }
}
