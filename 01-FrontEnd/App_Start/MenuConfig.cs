using Common;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FrontEnd.App_Start
{
    public class MenuConfig
    {
        public static void Initialize() {

            var _categoryService = DependecyFactory.GetInstance<ICategoryService>();
            Parameters.CategoryList = _categoryService.GetForMenu();
        }
    }
}