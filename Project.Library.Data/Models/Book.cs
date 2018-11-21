using Project.Library.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Data.Models
{
    public class Book : Base
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public int Quantity { get; set; }
        public DateTime YearPublished { get; set; }
    }
}
