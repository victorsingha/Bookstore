using CommonLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IBookRL
    {
        List<BookModel> GetBookList();
        List<BookModel> CartBooksByUserId(int userid);
        bool AddToCart(int UserId, int BookId);
    }
}
