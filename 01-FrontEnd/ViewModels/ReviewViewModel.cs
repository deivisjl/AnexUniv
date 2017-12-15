using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FrontEnd.ViewModels
{
    public class ReviewViewModel
    {
        public int CourseId { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public int Vote { get; set; }
    }
}