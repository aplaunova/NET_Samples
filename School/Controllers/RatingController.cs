using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Logic;
using School.Models;

namespace School.Controllers
{
    public class RatingController : Controller
    {
        public IActionResult Index()
        {
            var model = RatingManager.GetAll().Select(i => i.ToModel()).ToList();

                return View(model);
            
        }

        public IActionResult List(string name, string surname, string course)
        {
                var model = RatingManager.GetAll().Select(i => i.ToModel()).ToList();

                model = model.Where(i => i.Student.Name == name && i.Student.Surname == surname || i.Course.Course == course).ToList();
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
                using (var db = new DB())
                {
                    var student = StudentManager.GetAll().FirstOrDefault(c => c.Name == model.StudentName && c.Surname == model.StudentSurname);
                    var course = CourseManager.GetAll().FirstOrDefault(c => c.Course == model.CourseName);

                    if (student != null && course != null)
                    {
                        RatingManager.Add(model.StudentName, model.StudentSurname, model.CourseName, model.Rating,model.Description);
                        return RedirectToAction(nameof(Index));
                    }

                    
                    else
                    if (student == null)
                    {
                        ModelState.AddModelError("student", "Student not found!");
                    }
                    else
                    if (course == null)
                    {
                        ModelState.AddModelError("course", "Course not found!");
                    }

                   
                }
            }
            return View(model);
        }
    }
}


