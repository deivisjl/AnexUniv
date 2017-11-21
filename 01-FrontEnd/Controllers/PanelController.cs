using Common;
using Service;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize(Roles = RolNames.Admin)]
    public class PanelController : Controller
    {
        private IUserService _userService = DependecyFactory.GetInstance<IUserService>();
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
        public JsonResult Category(int id = 0)
        {
            return Json(null);
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
    }
}