using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class ImageUpdateDto
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
        public string TCNo { get; set; }

        public bool IsDelete { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
