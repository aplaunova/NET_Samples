using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCatalogStatic.Models
{
    public class CategoryModel
    {

        public int Id { get; set; }

        [Required]//obligati vajag noradit so ipasibu
        [DataType(DataType.Text)]
        [StringLength(20)]//max garums ipasibai
        [Display(Name = "Name:")]//ka vertiba bus attelota
        public string Name { get; set; }

    }
}
