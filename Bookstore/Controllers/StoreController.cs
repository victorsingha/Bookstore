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

        int GetUserId()
        {
            string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            HttpCookie authCookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            if (authCookie == null) return 0;
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); //Decrypt it
            string userId = ticket.Name; //You have the UserId!
            int id = Int32.Parse(userId);
            return id;
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

            int id = GetUserId();
            if(id == 0) Response.Redirect("https://localhost:44317/Store/Books");
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
            //if(submit == "checkout") return Content($"{cart.Customer.FullName}");
            if(submit == "checkout")
            {
                int userId = GetUserId();

                //var booklist = _bookBl.CartBooksByUserId(userId);
                //cart.BookList = booklist;
                bool result = _bookBl.PlaceOrder(cart,userId);
                if (result) return View(cart);
                else return Content("Order Fail");
             
            }
            
            return Content($"<h1>OTHER BUTTON</h1>");
        }
      
        
        public ActionResult AddToBag(BookModel book)
        {
            int id = GetUserId();
            if (id == 0) Response.Redirect("https://localhost:44317/Account/Login");
            //Pass UserId and BookId into Cart Table
            bool result = _bookBl.AddToCart(id, book.BookId);
            if(result) Response.Redirect("https://localhost:44317/Store/Books");
            return Content("Not Added To Bag");
        }
        [HttpPost]
        public ActionResult Remove()
        {
            int userId = GetUserId();
            string bookId = Request["remove"];
            int _bookId = Int32.Parse(bookId);
            bool result = _bookBl.RemoveFromCart(userId,_bookId);
            if (result) Response.Redirect("https://localhost:44317/Store/Cart");
            else Response.Redirect("https://localhost:44317/Store/Cart");
            return Content(userId + bookId);
        }

        public ActionResult MyOrders()
        {
            return View();
        }


    }
}