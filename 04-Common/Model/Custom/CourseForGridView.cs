using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Custom
{
    public class CourseForGridView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructor { get; set; }
        public int Students { get; set; }
        public int Lessons { get; set; }
        public Enums.Status Status { get; set; }
    }
}
