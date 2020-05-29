using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UserNews.Logic;
using UserNews.Models;

namespace UserNews.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(UserModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = UserManager.GetByEmailAndPassword(model.Email,model.Password).ToModel();

                if (user == null)
                {
                    ModelState.AddModelError("user", "Invalid e-mail/password");
                }
                else
                {
                    HttpContext.Session.SetUserName(user.Email) ;
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);

                    return RedirectToAction("List", "News");
                }
            }
            return View(model);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn", "User");
        }

    }
}