using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebLibrary;
using WebLibrary.Repository;
using WebNotes.Models;

namespace WebNotes.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserRepository userRepository) : base(userRepository)
        {
        }

        public ActionResult Index(HomeViewModel model)
        {
            if (CurrentUser.UserName == "admin")
                model.Log = Permission.Admin;
            else
                model.Log = Permission.Common;
            return View(model);
        }
    }
}