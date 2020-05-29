using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Logic;
using School.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        
        public IActionResult Index()
        {        
                var model = StudentManager.GetAll().Select(c => c.ToModel()).ToList();
                
                return View(model);
            
        }

        public IActionResult Average()
        {

            var student = StudentManager.GetAll().Select(c => c.ToModel()).ToList();

                foreach (var stu in student)
                {
                stu.AverageRating = StudentManager.AverageRating();
                }

                return View(student);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var model = new StudentModel();

            return View(model);
        }


        [HttpPost]
        public IActionResult Add(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                StudentManager.Add(model.Name, model.Surname, model.BirthdayYear, model.Class);

                return RedirectToAction("Index");
            }

            return View(model);
        }


    }
}



