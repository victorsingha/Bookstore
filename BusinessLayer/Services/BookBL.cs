using BusinessLayer.Interfaces;
using CommonLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BookBL : IBookBL
    {
        IBookRL _bookRl;
        public BookBL(IBookRL bookRl)
        {
            _bookRl = bookRl;
        }

        public bool AddToCart(int UserId, int BookId)
        {
            try
            {
                return _bookRl.AddToCart(UserId, BookId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<BookModel> CartBooksByUserId(int userid)
        {
            try
            {
                return _bookRl.CartBooksByUserId(userid);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<BookModel> GetBookList()
        {
            try
            {
                return _bookRl.GetBookList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public List<Order> GetOrdersByUserId(int UserId)
        {
            try
            {
                return _bookRl.GetOrdersByUserId(UserId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool PlaceOrder(Cart cart,int UserId)
        {
            try
            {
               return _bookRl.PlaceOrder(cart,UserId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public bool RemoveFromCart(int UserId, int BookId)
        {
            try
            {
                return _bookRl.RemoveFromCart(UserId, BookId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
