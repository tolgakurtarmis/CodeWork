using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Concrete
{
    public class BookTransaction : IEntity
    {
        [Key]

        public int Id { get; set; }
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
