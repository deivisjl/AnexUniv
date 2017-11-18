using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Model.Auth;
using System.ComponentModel;
using Model.Helper;

namespace Model.Domain
{
    public class UsersPerCourses : AuditEntity, Common.CustomFilters.ISoftDeleted
    {
        public int Id { get; set; }

        [DefaultValue(false)]
        public bool Completed { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public bool Deleted { get; set; }


    }
}
