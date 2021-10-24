using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeWork.Entities.Concrete
{
    public class Book : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int CoverImageId { get; set; }

        public string Title { get; set; }

        public DateTime AddedDate { get; set; }

        public string AddedDateTimeFormatted => AddedDate.Date();

        public int BookAuthorId { get; set; }

        [ForeignKey("BookAuthorId")]
        public virtual BookAuthor BookAuthor { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int PageNumber { get; set; }

        public string Description { get; set; }

        public string Barcode { get; set; }

        public int StockQuantity { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        
        [NotMapped]
        public string AuthorName { get; set; }
        public string SearchText { get; set; }

    }
}
