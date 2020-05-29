using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebCatalog.Models;

namespace WebCatalog.Controllers
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
                    Name = "Mobile"
                }
            });

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
                    Name = "Mobile"
                }


            });

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
        //id->kategorijas ID
        //?-pasaka, kas ID var but nedefinejams
        //filtre tikai tad, ja id ir definets
        public IActionResult Index(int? id)
        {
            var model = Items.OrderBy(i => i.Price).ToList();

            if (id.HasValue)
            {
                model = model.Where(i => i.Category.Id == id).ToList();
            }
            return View(model);
        }


        //ID-preces id
        public IActionResult View(int id)
        {
            var model = Items.Find(i => i.Id == id);

                return View(model);
        }
    }
}