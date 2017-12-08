using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class LessonCreateViewModel
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

    }
}