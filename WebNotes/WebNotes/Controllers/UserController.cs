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
    public class UserController : BaseController
    {
        public UserController(UserRepository userRepository) :
          base(userRepository)
        {
            this.userRepository = userRepository;
        }
        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().Get<UserManager>(); }
        }
        private UserRepository userRepository;
        
        // GET: User
        public ActionResult Index()
        {
          var model = new UserListViewModel
            {
                Users = userRepository.GetAll()
            };

            return View(model);
        }
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(AddUserViewModel model)
        {
            var user = model.GetUser();
            var result = UserManager.CreateAsync(user, model.Password);

            if (!result.Result.Succeeded)
            {
                foreach (var error in result.Result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
           if(CurrentUser==null)
            {
                UserManager.CreateAsync(user, model.Password);
                return RedirectToAction("Login", "Account");
            }
           else
            {
                return RedirectToAction("Index", "User");
            }
                return RedirectToAction("Index", "User");
            
           
        }
        
    

        [HttpPost]
        public ActionResult Change(EditViewModel model)
        {

            var u = userRepository.Load(model.Id);

            u.Id = model.Id;
            u.UserName = model.UserName;
            u.FirstName = model.FirstName;
            u.LastName = model.LastName;
            u.SecondName = model.SecondName;
            u.Email = model.Email;
            u.Status = model.Status;
            u.DateofBirth = Convert.ToDateTime(model.DateofBirth);
            userRepository.Save(u);
            return RedirectToAction("Index", "User");
        }
        public ActionResult Change(long id)
        {
            var user = userRepository.Load(id);
            return View(new EditViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                UserName = user.UserName,
                Status = user.Status,
                LastName = user.LastName,
                SecondName = user.SecondName,
                Email = user.Email
            });
        }
    }
}