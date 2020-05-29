using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Controllers
{
    public class RatingController : Controller
    {
        public static List<RatingModel> Ratings = new List<RatingModel>();
        
        public IActionResult Index(string studentSurname, string courseName)
        {
            var model = Ratings.OrderByDescending(i => i.Rating).ToList();

            /*if (id.HasValue)
            {*/
                model = model.Where(i => i.Student.Surname == studentSurname).Where(i=>i.Course.Course==courseName).ToList();
           /* }*/
          
          
            return View(model);
        }

        public IActionResult View(int id)
        {
            var model = Ratings.Find(i => i.Student.Id == id && i.Course.Id==id);

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new RatingModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(RatingModel model)
        {
            if (ModelState.IsValid)
            {
                model.Student = StudentController.Students.Find(c => c.Surname == model.StudentSurname);

                model.Course = CourseController.Courses.Find(c => c.Course == model.CourseName);

               /*model.StudentId = Ratings.Count + 1;*/
                Ratings.Add(model);

                
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}