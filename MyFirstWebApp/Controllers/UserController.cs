using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MyFirstWebApp.Logic;
using MyFirstWebApp.Models;

namespace MyFirstWebApp.Controllers
{
    public class UserController : Controller
    {

        //https://localhost:44365/User
        //https://localhost:44365/User/Index

        public IActionResult Index()
        {

            //ar prefiksu u nak no datubazes. Transforme datus
            var users = UserManager.GetAll().Select(u => u.ToModel()).ToList();



                return View(users);
            
        }

        //https://localhost:44365/User/View
        public IActionResult View(int id)//apskatit vienu konkreto lietotaju
        {

         
                //select Id,Name,Email,Phone from Users where Id=@id

                var user = UserManager.Get(id).ToModel();

                return View(user);
           
            
        }

        //https://localhost:44365/User/Add
        [HttpGet]
        //lietotaja pievienosana
        public IActionResult Add()
        {
            var user = new UserModel();
            return View(user);
        }

        [HttpPost]//datu iesutisana
        public IActionResult Add(UserModel model)
        {
            if (ModelState.IsValid)//izmanto, ko noradijam pie Model ipasibam
            {
                //VISS OK-modelis ir valids, var veikt datu saglabasanu

                //seit notiek preteja transformacija
                //insert into Users(Email, Phone, Name)
                //values(@email,@phone,@name)
                //COMMIT
                UserManager.Create(model.Name, model.Email, model.Phone);
                    return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}