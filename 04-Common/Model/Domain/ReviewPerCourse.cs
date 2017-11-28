using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class ReviewPerCourse : AuditEntity, Common.CustomFilters.ISoftDeleted
    {
        public int Id { get; set; }
        [Required]
        public decimal Vote { get; set; }
        [Required]
        public string Comment { get; set; }

        public Course Course { get; set; }
        [Required]
        public int CourseId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }

        public bool Deleted { get; set; }
    }
}
