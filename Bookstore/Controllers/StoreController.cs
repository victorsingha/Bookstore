using CommonLayer;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bookstore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Books()
        {
            BookModel book = new BookModel();
            List<BookModel> books = new List<BookModel>
            {
                new BookModel {BookId = 1,Name = "UX Design",Author = "Cabbage",Image = "https://static-cse.canva.com/blob/142538/Purple-and-Red-Leaves-Illustration-Childrens-Book-Cover.jpg",Rating = "4.5",Reviews = 22,OriginalPrice = 2000,DiscountPrice = 1200},
                new BookModel {BookId = 2,Name = "UX Design",Author = "Cabbage",Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEcbvZUQNVbxQJv9SeZVQ79MOd6ucMSUeMUg&usqp=CAU",Rating = "4.1",Reviews = 62,OriginalPrice = 2200,DiscountPrice = 1000},
                new BookModel {BookId = 3,Name = "UX Design",Author = "Cabbage",Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEcbvZUQNVbxQJv9SeZVQ79MOd6ucMSUeMUg&usqp=CAU",Rating = "4.3",Reviews = 42,OriginalPrice = 4000,DiscountPrice = 1300},
                new BookModel {BookId = 4,Name = "UX Design",Author = "Cabbage",Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEcbvZUQNVbxQJv9SeZVQ79MOd6ucMSUeMUg&usqp=CAU",Rating = "4.8",Reviews = 29,OriginalPrice = 8000,DiscountPrice = 1700},
                new BookModel {BookId = 5,Name = "UX Design",Author = "Cabbage",Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEcbvZUQNVbxQJv9SeZVQ79MOd6ucMSUeMUg&usqp=CAU",Rating = "3.5",Reviews = 35,OriginalPrice = 5400,DiscountPrice = 2700},
                new BookModel {BookId = 6,Name = "UX Design",Author = "Cabbage",Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEcbvZUQNVbxQJv9SeZVQ79MOd6ucMSUeMUg&usqp=CAU",Rating = "5.0",Reviews = 23,OriginalPrice = 2010,DiscountPrice = 1000}
            };
            //Passing list of books in Store/books page.
            return View(books);
        }

        public ActionResult BookDetail(BookModel book)
        {
            //Getting one book object from store/books page
            //Passing the object to View
            return View(book);
        }
    }
}