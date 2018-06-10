using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLibrary;
using WebLibrary.Repository;
using WebNotes.Fold;
using WebNotes.Models;

namespace WebNotes.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(UserRepository userRepository) :
            base(userRepository)
        {

        }
        public ActionResult Login()
        {
            if (userRepository.FindByLogin("admin") == null)
            {
                CreateUser("admin", "123456");
            }
            return View();
        }
  

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = userRepository.FindByLogin(model.UserName);
                if (user.Status == Status.Active)
                {
                    var result = SignInManager.PasswordSignIn(model.UserName, model.Password, false, false);
                    if (result == SignInStatus.Success)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Неверное имя пользователя или пароль");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Учетная запись заблокирована!");
                }
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            SignInManager.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult CreateUser(string Login, string Password)
        {
            var user = new User { UserName = Login };
            var result = UserManager.CreateAsync(user, Password);
            if (result.Result.Succeeded)
            {
               user = userRepository.Load(1);
                user.Status = Status.Active;
                user.Permission = Permission.Admin;
                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var error in result.Result.Errors)
                {
                    ModelState.AddModelError("", "");
                }
                return RedirectToAction("Index", "Home");
            }
        }

        

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}