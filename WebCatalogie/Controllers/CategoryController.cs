using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCatalog.Models;

namespace WebCatalog.Controllers
{
    public class CategoryController : Controller
    {
        public List<CategoryModel> Categories;

        public CategoryController()
        {
            Categories = new List<CategoryModel>();
            Categories.Add(new CategoryModel()
            {
                Id = 1,
                Name = "Mobile",
            });

        Categories.Add(new CategoryModel()
        {
            Id = 2,
            Name = "Computers",
        });

        Categories.Add(new CategoryModel()
        {
            Id = 3,
            Name = "TV",
        });
        }
    

    
        
        
        //1.a
        public IActionResult Index()
        {
        var model = Categories.OrderBy(c=>c.Name).ToList();
        return View(model);
        }

        //1.b
        public IActionResult View(int id)
        {
            return View();
        }
    }
}