using BusinessLayer.Interfaces;
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class AccountController : Controller
    {
        private IUserBL _userBl;
        public AccountController(IUserBL userBl)
        {
            _userBl = userBl;
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
            //return Content("<h1>LOGIN PAGE</h1>");   
        }

        [HttpPost]
        public ActionResult Authenticate()
        {
            string submit = Request["submit"];
            string email = Request["email"];
            string password = Request["password"];

            LoginModel loginmodel = new LoginModel();
            loginmodel.Email = email;
            loginmodel.Password = password;

            bool result = _userBl.Authenticate(loginmodel);

            if (submit == "login") return Content($"Login Success {email} {password}");
            if (submit == "facebook") return Content("Login with Facebook.");
            if (submit == "google") return Content("Login with google");

            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser()
        {
            string fullname = Request["fullname"];
            string email = Request["email"];
            string password = Request["password"];
            string mobile = Request["mobile"];
            return Content($"{fullname} + {email} + {password} + {mobile}");

        }
    }
}