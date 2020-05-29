using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Logic;
using School.Models;

namespace School.Controllers
{
    public class CourseController : Controller
    {

        public IActionResult Index()
        {

                var model = CourseManager.GetAll().Select(c => c.ToModel()).ToList();

                return View(model);
            
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CourseModel();

            return View(model);
        }


        [HttpPost]
        public IActionResult Add(CourseModel model)
        {
            if (ModelState.IsValid)
            {
            CourseManager.Add(model.Course);

            return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}