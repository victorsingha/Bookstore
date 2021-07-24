using Bookstore.Filters;
using BusinessLayer.Interfaces;
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        //[CustomAuthentication]
        public ActionResult Login()
        {          
            LoginModel loginModel = new LoginModel();
            return View(loginModel);
        }

        [HttpPost]
        public ActionResult Authenticate(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                string submit = Request["submit"];
                if (submit == "login")
                {
                    int userid = _userBl.Authenticate(loginModel);
                    if (userid != 0)
                    {
                        FormsAuthentication.SetAuthCookie(userid.ToString(), false);
                        // If Login Successfull Redirect to Store/Books
                        Response.Redirect("https://localhost:44317/Store/Books");
                        return Content("<h1>Login Success</h1>");
                    }
                    else return Content("Login Fail !!");
                }
                if (submit == "facebook") return Content("Login with Facebook.");
                if (submit == "google") return Content("Login with google");

            }
            return View("Login",loginModel);
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

            RegisterModel model = new RegisterModel();
            model.FullName = fullname;
            model.Email = email;
            model.Password = password;
            model.Mobile = mobile;

            bool result = _userBl.Register(model);
            if (result) return Content("<h1>Registration Success</h1>");
            else return Content("<h1>Registration Fail !!</h1>");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            return RedirectToAction("Login");
        }

    }
}