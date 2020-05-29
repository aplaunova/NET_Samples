using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using WebShop.Logic;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                //parbaudit vai paroles sakrit
                //vai lietotajs ar e-pastu jau neeksiste
                if (model.Password != model.PasswordRepeat)
                {
                    ModelState.AddModelError("pass", "Passowrd do not match!");
                }
                else 
                {
                    //todo: lietotaja atlase no DB pes e-pasta. Izmantojot UserMnagaer
                    UserModel user = UserManager.GetByEmail(model.Email).ToModel();

                    if (user != null)
                    {
                        ModelState.AddModelError("mail", "User with this e-mail already exists!");
                    }
                    else
                    {
                        //TODO: saglabas ievaditos datus DB, izmantojot UserManager
                        UserManager.Create(model.Email, model.Name, model.Password);

                        return RedirectToAction(nameof(SignIn));
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //todo: lietotaja atlase no DB pec epasta un paroles. Using UserManager
                UserModel user = UserManager.GetByEmailAndPassword(model.Email,model.Password).ToModel();

                if (user == null)
                {
                    ModelState.AddModelError("user", "Invalid e-mail/password");
                }
                else
                {
                    //saglaba lietotaja datus sessija
                    HttpContext.Session.SetUserName(user.Name);
                    HttpContext.Session.SetUserId(user.Id);
                    HttpContext.Session.SetIsAdmin(user.IsAdmin);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult MyCart()
        {
            //todo: veikta lietotaja groza atlasi no DB, izmantojot UserCart Manager
            var userCart = UserCartManager.GetByUser(HttpContext.Session.GetUserId());
            //todo: attelot lietotaja groza saturu
            var items = userCart.Select(c => c.Item.ToModel()).ToList();

            foreach (var item in items)
            {
                item.ItemCount = UserCartManager.GetItemCount(item.Id);
            }

            return View(items);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            UserCartManager.DeleteByItem(id);

            return RedirectToAction(nameof(MyCart));
        }

        public IActionResult Confirm()
        {
            UserCartManager.DeleteByUser(HttpContext.Session.GetUserId());

            return View();
        }
    }
}