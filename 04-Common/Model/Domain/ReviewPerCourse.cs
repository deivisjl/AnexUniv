using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ReviewPerCourse
    {
        public int Id { get; set; }
        public decimal Vote { get; set; }
        public string Comment { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
