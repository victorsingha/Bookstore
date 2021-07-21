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
        public ActionResult Login()
        {
            return View();
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

            
            if (submit == "login")
            {
                int userid = _userBl.Authenticate(loginmodel);
                if (userid != 0)
                { 
                    FormsAuthentication.SetAuthCookie(userid.ToString(), true);
                   
                    string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
                    HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
                    string userId = ticket.Name; //You have the UserId!
                    
                    // If Login Successfull Redirect to Store/Books
                    Response.Redirect("https://localhost:44317/Store/Books");
                    return Content("<h1>Login Success</h1>");
                } 
                else return Content("Login Fail !!");
            } 
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

            RegisterModel model = new RegisterModel();
            model.FullName = fullname;
            model.Email = email;
            model.Password = password;
            model.Mobile = mobile;

            bool result = _userBl.Register(model);
            if (result) return Content("<h1>Registration Success</h1>");
            else return Content("<h1>Registration Fail !!</h1>");
        }
    }
}