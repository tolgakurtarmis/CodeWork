using CodeWork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class BookTransactionDto
    {

        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public string AddedDateTimeFormatted => AddedDate.Date();
        public DateTime? ModifiedDateTime { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int SalesQuantity { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string ReturnDateFormatted => ReturnDate?.Date();

    }
}
