using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeList.Models;
using EmployeeList.Database;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeList.Controllers
{
    public class EmployeeController : Controller
    {

        public IActionResult Index()
        {
            using (var db = new DB())
            {
                var model = db.Employees.OrderBy(c => c.Department).ThenBy(c=>c.Surname).Select(c => new EmployeeModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname=c.Surname,
                    /*DoB=c.DoB,*/
                    Position=c.Position,
                    Department=c.Department,
                }).ToList();
                return View(model);
            }
        }


        public IActionResult View(int id)
        {
            using (var db = new DB())
            {
                var emp = db.Employees.Find(id);


                var model = new EmployeeModel()
                {
                    Id = emp.Id,
                    Name=emp.Name,
                    Surname=emp.Surname,
                    /*DoB=emp.DoB,*/
                    Position=emp.Position,
                    Department=emp.Department,

                };

                return View(model);
            }
        }




        public IActionResult Department()
        {
            using (var db = new DB())
            {
               
                var model = db.Employees.Select(c => new EmployeeModel()
                {
                    Department = c.Department,
                }).Distinct().ToList();

                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new EmployeeModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                //saglabasana
                using (var db = new DB())
                {
                    db.Employees.Add(new Database.Employees()
                    {
                        Name = model.Name,
                        Surname=model.Surname,
                        Position=model.Position,
                        Department=model.Department,
                    });
                    db.SaveChanges();
                }

                //pareja uz sarakstu
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }



    }
}