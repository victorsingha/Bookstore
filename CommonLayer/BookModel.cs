using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLayer
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public string Rating { get; set; }
        public int Reviews { get; set; }
        public int OriginalPrice { get; set; }
        public int DiscountPrice { get; set; }
    }
}
