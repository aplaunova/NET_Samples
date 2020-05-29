using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB_Catalog.Models;

namespace WEB_Catalog.Controllers
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
                Id = 1,
                Name = "TV",
            });
        }


        public IActionResult Index()
        {
            var model = Categories.OrderBy(c => c.Name).ToList();
            return View(model);
        }

        public IActionResult View(int id)
        {
            return View();
        }
    }
}