using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        public static List<StudentModel> Students = new List<StudentModel>();
        
        public IActionResult Index()
        {
            var model = Students.OrderBy(c => c.Surname).ThenBy(c=>c.Name).ToList();
            
            return View(model);
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
                //saglabasan
                model.Id = Students.Count + 1;
                Students.Add(model);

                //pareja uz sarakstu
                return RedirectToAction("Index");
            }

            return View(model);
        }


    }
}



