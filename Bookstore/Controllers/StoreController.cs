using BusinessLayer.Interfaces;
using CommonLayer;
using System.Collections.Generic;
using System.Web.Mvc;

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
            Customer customer = new Customer();
            Cart cart = new Cart();

            var booklist = _bookBl.GetBookList();
        
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