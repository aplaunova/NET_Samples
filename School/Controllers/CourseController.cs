using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Controllers
{
    public class CourseController : Controller
    {
        public static List<CourseModel> Courses = new List<CourseModel>();

        public IActionResult Index()
        {
            var model = Courses.OrderBy(c => c.Course).ToList();

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
                //saglabasan
                model.Id = Courses.Count + 1;
                Courses.Add(model);

                //pareja uz sarakstu
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}