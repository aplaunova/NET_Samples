using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage;
using WebCatalogStatic.Models;
using WebCatalogStatic.Database;

namespace WebCatalogStatic.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index(int? id)
        {
            using (var db = new DB())
            {
                var model = db.Items.OrderBy(i => i.Price).Select(i => new ItemModel()
                {
                    Id = i.Id,
                    Description = i.Description,
                    Location = i.Location,
                    Name = i.Name,
                    Price = i.Price,
                    Category = new CategoryModel()
                    {
                        Id = i.CategoryId,
                    }
                }).ToList();

                if (id.HasValue)
                {
                    model = model.Where(i => i.Category.Id == id).ToList();
                }

                return View(model);

            }
        }


        public IActionResult View(int id)
        {
            using (var db = new DB())
            {
                var item = db.Items.Find(id);


                var model = new ItemModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    Location = item.Location,
                    Name = item.Name,
                    Price =item.Price,
                    Category = new CategoryModel()
                    {
                        Id = item.CategoryId,
                    }
                    
                };
                model.Category.Name = db.Categories.Find(model.Category.Id).Name;

                return View(model);
            }
        }


        [HttpGet]
        //lietotaja pievienosana
        public IActionResult Create()
        {
            var model = new ItemModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ItemModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new DB())
                {
                    var category = db.Categories.FirstOrDefault(c => c.Name == model.CategoryName);

                    if (category != null)
                    {
                        db.Items.Add(new Database.Items()
                        {
                            Price = model.Price,
                            Name = model.Name,
                            Location = model.Location,
                            Description = model.Description,
                            CategoryId = category.Id,
                        });
                        db.SaveChanges();

                        return RedirectToAction(nameof(Index));
                    }

                    else
                    {
                        ModelState.AddModelError("cat", "Category not found!");
                    }
                }
            }

            return View(model);
        }

    }
}