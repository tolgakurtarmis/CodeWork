using CodeWork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }


        public int CoverImageId { get; set; }

        public virtual Image CoverImage { get; set; }

        public string Title { get; set; }

        public DateTime AddedDate { get; set; }

        public string AddedDateTimeFormatted => AddedDate.Date();

        public int BookAuthorId { get; set; }

        public virtual BookAuthor BookAuthor { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int PageNumber { get; set; }

        public string Description { get; set; }

        public string Barcode { get; set; }

        public int StockQuantity { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public string AuthorName { get; set; }

        public string SearchText { get; set; }
    }
}
