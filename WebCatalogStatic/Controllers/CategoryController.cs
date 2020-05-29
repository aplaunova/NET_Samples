using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using WebCatalogStatic.Models;
using WebCatalogStatic.Database;


namespace WebCatalogStatic.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new DB())
            {
                var model = db.Categories.OrderBy(c => c.Name).Select(c => new CategoryModel()
                {
                 Id=c.Id,
                 Name=c.Name,
                }).ToList();
                return View(model);
            }
        }
        

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                //saglabasana
                using (var db = new DB())
                {
                    db.Categories.Add(new Database.Categories()
                    {
                        Name = model.Name,
                    });
                    db.SaveChanges();
                }

                //pareja uz sarakstu
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}