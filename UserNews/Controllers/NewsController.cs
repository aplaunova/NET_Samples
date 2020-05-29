using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserNews.Models;
using UserNews.Logic;


namespace UserNews.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult List()
        {

            var news= NewsManager.GetAll().Select(c => c.ToModel()).ToList();
            return View(news);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }
            var model = new NewsModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(NewsModel model)
        {
            if (ModelState.IsValid)
            {
                NewsManager.Create(model.Name, model.Content);
                return RedirectToAction(nameof(List));
            }

            return View(model);
        }
    }
}