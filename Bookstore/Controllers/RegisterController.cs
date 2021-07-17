using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
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