using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeList.Models
{
    public class EmployeeModel
    {

        public int Id { get; set; }

        [Required]       
        [DataType(DataType.Text)]
        [StringLength(20)]
        [Display(Name = "Name:")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Surname:")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "DoB:")]
        public DateTime DoB { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        [Display(Name = "Position:")]
        public string Position { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(30)]
        [Display(Name = "Department:")]
        public string Department { get; set; }


    }
}
