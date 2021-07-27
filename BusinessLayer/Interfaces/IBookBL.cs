using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IBookBL
    {
        List<BookModel> GetBookList();
        List<BookModel> CartBooksByUserId(int userid);
        bool AddToCart(int UserId, int BookId);
        bool AddToWishlist(int UserId, int BookId);
        bool RemoveFromCart(int UserId, int BookId);
        bool PlaceOrder(Cart cart,int UserId);
        List<Order> GetOrdersByUserId(int UserId);
    }
}
