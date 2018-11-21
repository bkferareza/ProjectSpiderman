using Project.Library.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Data.Models
{
    public class Transaction : Base
    {
        public Borrower Borrower { get; set; }
        public Book Book { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime Time { get; set; }
    }
}
