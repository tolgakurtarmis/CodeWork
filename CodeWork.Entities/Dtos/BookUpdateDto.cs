using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class BookUpdateDto
    {
        public int Id { get; set; }

        public int CoverImageId { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int PageNumber { get; set; }

        public string Description { get; set; }

        public string Barcode { get; set; }

        public int StockQuantity { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public int BookAuthorId { get; set; }

    }
}
