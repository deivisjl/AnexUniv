using Common;
using FrontEnd.App_Start;
using Service;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = RolNames.Admin)]
    public class PanelController : Controller
    {
        private IUserService _userService = DependecyFactory.GetInstance<IUserService>();
        private ICategoryService _categoryService = DependecyFactory.GetInstance<ICategoryService>();
        private IWidgetService _widgetService = DependecyFactory.GetInstance<IWidgetService>();
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetCategory(int id) {

            return Json(_categoryService.Get(id));
        }

        [HttpPost]
        public JsonResult GetCategories(AnexGRID grid)
        {

            return Json(_categoryService.GetAll(grid));
        }


        [HttpPost]
        public JsonResult Category(int id = 0)
        {
            return Json(null);
        }

        [HttpPost]
        public JsonResult CategorySave(Model.Domain.Category model)
        {
            var rh = new ResponseHelper();

            if (!ModelState.IsValid)
            {
                var validations = ModelState.GetErrors();
                rh.SetValidations(validations);
            }
            else {
                rh = _categoryService.InsertOrUpdate(model);
                if (rh.Response) {

                    rh.Href = "self";
                }
            }

            return Json(rh);
        }

        public ActionResult Courses()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

       [HttpPost]
        public JsonResult GetUsers(AnexGRID grid) {
            return Json(
                    _userService.GetAll(grid)
                );
        }

        #region Widget
        [HttpPost]
        public JsonResult WidgetGetIncomes(bool month)
        {
            return Json(
                _widgetService.Incomes(month)
            );
        }

        [HttpPost]
        public JsonResult WidgetGetVariance()
        {
            return Json(
                _widgetService.Variance()
            );
        }

        [HttpPost]
        public JsonResult WidgetGetAverage()
        {
            return Json(
                _widgetService.Average()
            );
        }
        #endregion
    }
}