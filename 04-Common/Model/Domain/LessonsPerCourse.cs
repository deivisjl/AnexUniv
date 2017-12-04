using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class LessonsPerCourse : AuditEntity, Common.CustomFilters.ISoftDeleted
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        public string Video { get; set; }

        public Course Course { get; set; }
        [Required]
        public int CourseId { get; set; }

        public bool Deleted { get; set; }
    }
}
