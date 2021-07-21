using BusinessLayer.Interfaces;
using CommonLayer;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Bookstore.Controllers
{
    public class StoreController : Controller
    {
        IBookBL _bookBl;
        public StoreController(IBookBL bookBl)
        {
            _bookBl = bookBl;
        }
        // GET: Store
        public ActionResult Books()
        {
            var booklist = _bookBl.GetBookList();
          
            //Passing list of books in Store/books page.
            return View(booklist);
        }

        public ActionResult Preview(BookModel book)
        {
            //Getting one book object from store/books page
            //Passing the object to View
            return View(book);
        }

        public ActionResult Cart()
        {
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string userId = ticket.Name; //You have the UserId!
            int id = Int32.Parse(userId);

            Customer customer = new Customer();
            Cart cart = new Cart();

            var booklist = _bookBl.CartBooksByUserId(id);
        
            cart.BookList = booklist;
            cart.Customer = customer;
            return View(cart);
        }
        [HttpPost]
        public ActionResult Checkout(Cart cart)
        {
            string submit = Request["submit"];
            if(submit == "checkout") return Content($"{cart.Customer.FullName}");
            return Content($"<h1>OTHER BUTTON</h1>");
        }
    }
}