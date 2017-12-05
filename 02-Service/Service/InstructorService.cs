using Common;
using Microsoft.Owin.Logging;
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
    public interface IInstructorService {
        IEnumerable<InstructorCourseForGridView> GetAll(string userId);
        InstructorWidget Widget(string userId);
    }
    class InstructorService : IInstructorService
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Course> _courseRepository;

        public InstructorService(
            IDbContextScopeFactory dbContextScopeFactory,
            IRepository<Course> courseRepository
            )
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _courseRepository = courseRepository;
        }

        public IEnumerable<InstructorCourseForGridView> GetAll(string userId)
        {
            var result = new List<InstructorCourseForGridView>();

            try {

                using (var ctx = _dbContextScopeFactory.CreateReadOnly()) {

                    var courses = ctx.GetEntity<Course>();
                    var usersPerCourses = ctx.GetEntity<UsersPerCourses>();
                    var incomes = ctx.GetEntity<Incomes>();

                    var queryIncome = incomes.Where(x =>
                        x.EntityType == Enums.EntityType.Courses
                        && x.IncomeType == Enums.IncomeType.TeacherTotal
                    );

                    var currentYear = DateTime.Now.Year;
                    var currentMonth = DateTime.Now.Month;

                    result = (
                        from c in courses.Where(x => x.AuthorId == userId)
                        select new InstructorCourseForGridView
                        {
                            Id = c.Id,
                            Name = c.Name,
                            Description = c.Description,
                            Image = c.Image2,
                            Students = usersPerCourses.Count(x => x.CourseId == c.Id),
                            Total = queryIncome.Where(
                                x => x.EntityID == c.Id
                                ).Select(x => x.Total).DefaultIfEmpty().Sum(),
                            
                            TotalPerMonth = queryIncome.Where(
                                x => x.EntityID == c.Id 
                                && x.CreatedAt.Value.Year == currentYear
                                && x.CreatedAt.Value.Month == currentMonth
                                ).Select(x => x.Total).DefaultIfEmpty().Sum(),
                        }
                        ).ToList();
                }
            } catch (Exception e) {
                logger.Error(e.Message);
            }

            return result;
        }

        public InstructorWidget Widget(string userId)
        {
            var result = new InstructorWidget();

            try
            {

                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {

                    var courses = ctx.GetEntity<Course>();
                    var usersPerCourses = ctx.GetEntity<UsersPerCourses>();
                    var incomes = ctx.GetEntity<Incomes>();
                    var reviewPerCourse = ctx.GetEntity<ReviewPerCourse>();

                    var queryIncome = incomes.Where(x =>
                        x.EntityType == Enums.EntityType.Courses
                        && x.IncomeType == Enums.IncomeType.TeacherTotal
                    );

                    var queryCourse = courses.Where(x => x.AuthorId == userId);

                    var currentYear = DateTime.Now.Year;
                    var currentMonth = DateTime.Now.Month;

                    result.Total = queryIncome.Where(x =>
                        queryCourse.Any(y => y.Id == x.EntityID)
                        && x.CreatedAt.Value.Year == currentYear
                        && x.CreatedAt.Value.Month == currentMonth
                    ).Select(x => x.Total).DefaultIfEmpty().Sum();

                    result.Students = usersPerCourses.Where(x =>
                        queryCourse.Any(y => y.Id == x.CourseId)
                    ).Count();

                    result.Reputation = reviewPerCourse.Where(x =>
                        queryCourse.Any(y => y.Id == x.CourseId)
                    ).Select(x => x.Vote).DefaultIfEmpty().Average();
                    
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }
    }
}
