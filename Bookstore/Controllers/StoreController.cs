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
            return View();
        }
        [HttpPost]
        public ActionResult CustomerDetails(Customer customer)
        {
            string na = customer.FullName;
            string dsa = customer.Mobile;
            string ds = customer.City;
            return Content($"{na} {dsa} {ds}");
        }
    }
}