using CodeWork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class BookTransactionCreateDto
    {
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int SalesQuantity { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
