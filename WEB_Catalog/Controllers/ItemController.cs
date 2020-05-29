using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WEB_Catalog.Models;

namespace WEB_Catalog.Controllers
{
    public class ItemController : Controller
    {
        public List<ItemModel> Items;

        public ItemController()
        {
            Items = new List<ItemModel>();
            Items.Add(new ItemModel()
            {
                Id = 1,
                Name = "Samsung Galaxy S6",
                Price = 200,
                Location = "Riga",
                Description = "My super phone",
                Category = new CategoryModel()
                {
                    Id = 1,
                    Name = "Phones"
                }
            });

            Items = new List<ItemModel>();
            Items.Add(new ItemModel()
            {
                Id = 2,
                Name = "Samsung Galaxy S5",
                Price = 100,
                Location = "Riga",
                Description = "My super phone",
                Category = new CategoryModel()
                {
                    Id = 1,
                    Name = "Phones"
                }
            });

            Items = new List<ItemModel>();
            Items.Add(new ItemModel()
            {
                Id = 3,
                Name = "Sony Smart Tv",
                Price = 800,
                Location = "Riga",
                Description = "Best TV",
                Category = new CategoryModel()
                {
                    Id = 3,
                    Name = "TV"
                }
            });
        }

        public IActionResult Index(int? id)
        {
            var model = Items.Where(i => i.Category.Id == id)
                .OrderBy(i => i.Price)
                .ToList();

            if (id.HasValue)
            {
                model = model.Where(i => i.Category.Id == id).ToList();
            }
            return View(model);
        }

        public IActionResult View(int id)
        {
            var model = Items.Find(i => i.Id == id);

            return View(model);
        }

    }
}