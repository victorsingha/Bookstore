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
    }
}
