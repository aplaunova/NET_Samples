using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name="Name: ")]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname: ")]
        [DataType(DataType.Text)]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Birthday Year: ")]
        public int BirthdayYear { get; set; }

        [Required]
        [Display(Name = "Class: ")]
        [DataType(DataType.Text)]
        [StringLength(3)]
        public string Class { get; set; }
    
    }
}
