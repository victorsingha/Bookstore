using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class Cart
    {
        public List<BookModel> BookList { get; set; }
        public Customer Customer { get; set; }
    }
}
