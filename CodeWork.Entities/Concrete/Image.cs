using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Concrete
{
    public class Image : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public string ImageWithPath => Path + (Id != 1 ? Id.ToString().ToCharArray()[0] + "/" : "") + Name;

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
