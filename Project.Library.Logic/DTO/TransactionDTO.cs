using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Library.Logic.DTO
{
    public class TransactionDTO : Base
    {
        public BorrowerDTO Borrower { get; set; }
        public BookDTO Book { get; set; }
        public string TransactionType { get; set; }
        public DateTime Time { get; set; }

    }
}
