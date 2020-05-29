using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]//obligati vajag noradit so ipasibu
        [DataType(DataType.Text)]
        [StringLength(50)]//max garums ipasibai
        [Display(Name="Name:")]//ka vertiba bus attelota

        public string Name { get; set; }

        [Required]//obligati vajag noradit so ipasibu
        [DataType(DataType.EmailAddress)]
        [StringLength(200)]//max garums ipasibai
        [Display(Name = "E-mail:")]

        public string Email { get; set; }



        [DataType(DataType.PhoneNumber)]
        [StringLength(15)]//max garums ipasibai
        [Display(Name = "Phone number:")]
        public string Phone { get; set; }
    }
}
