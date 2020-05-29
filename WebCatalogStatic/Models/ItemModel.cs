using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCatalogStatic.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        
        [Required]//obligati vajag noradit so ipasibu
        [DataType(DataType.Text)]
        [StringLength(50)]//max garums ipasibai
        [Display(Name = "Name:")]//ka vertiba bus attelota
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [StringLength(200)]//max garums ipasibai
        [Display(Name = "Description:")]//ka vertiba bus attelota
        public string Description { get; set; }

        [Required]//obligati vajag noradit so ipasibu
        [Display(Name = "Price:")]//ka vertiba bus attelota
        public decimal Price { get; set; }

        [DataType(DataType.Text)]
        [StringLength(150)]//max garums ipasibai
        [Display(Name = "Location:")]//ka vertiba bus attelota
        public string Location { get; set; }


        [DataType(DataType.Text)]
        [StringLength(20)]//max garums ipasibai
        [Display(Name = "Category:")]//ka vertiba bus attelota
        public string CategoryName { get; set; }



        public CategoryModel Category { get; set; }
    }
}
