using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Course: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Course { get; set; }
    }
}
