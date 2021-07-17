using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
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
            if(submit == "login") return Content($"Login Success {email} {password}");
            if(submit == "facebook") return Content("Login with Facebook.");
            if(submit == "google") return Content("Login with google");

            return View();
        }
    }
}