using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class RatingModel
    {
        public int StudentId { get; set; }
        
        [Display(Name = "Name: ")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string StudentName { get; set; }

        [Display(Name = "Surname: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string StudentSurname { get; set; }
        
        public StudentModel Student { get; set; }

        [Display(Name = "Course: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string CourseName { get; set; }

        public CourseModel Course { get; set; }

        [Required]
        [Display(Name = "Rating: ")]
        public int Rating {get;set;}

        [Display(Name = "Description: ")]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
