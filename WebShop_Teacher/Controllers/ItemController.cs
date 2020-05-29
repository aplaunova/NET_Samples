using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index(int id)
        {
            // id -> kategorijas ID
            var model = new HomeModel();
            model.Categories = CategoryManager.GetAll().Select(c => c.ToModel()).ToList();
            model.Items = ItemManager.GetByCategory(id).Select(c => c.ToModel()).ToList();

            return View(model);
        }

        public IActionResult List()
        {
            var items = ItemManager.GetAll().Select(c => c.ToModel()).ToList();
            return View(items);
        }

        [HttpGet]
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
                var category = CategoryManager.Get(model.CategoryId);
                if (category == null)
                {
                    ModelState.AddModelError("cat", "Category not found!");
                }
                else
                {
                    ItemManager.Create(category.Id, model.Name, model.Description, model.Price);
                    return RedirectToAction(nameof(List));
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ItemManager.Delete(id);

            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            UserCartManager.Create(HttpContext.Session.GetUserId(), id);
            return RedirectToAction("MyCart", "Account");
        }
    }
}