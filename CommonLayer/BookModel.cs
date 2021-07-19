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
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public int ReviewCount { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public string InStock { get; set; }
    }
}
