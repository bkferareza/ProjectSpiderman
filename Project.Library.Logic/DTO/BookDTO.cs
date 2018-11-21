using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Logic.DTO
{
    public class BookDTO : Base
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Quantity { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
