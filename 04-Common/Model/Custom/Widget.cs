using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class WidgetIncome
    {
        public decimal Total { get; set; }
        public decimal Company { get; set; }
        public decimal Instructors { get; set; }
    }

    public class WidgetStatistics
    {
        public decimal IncomeCompany { get; set; }
        public decimal NewStudents { get; set; }
        public decimal NewCourses { get; set; }
    }
}
