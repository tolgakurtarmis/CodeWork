using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class MemberCreateDto
    {
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool IsActive => true;
        public string TCNo { get; set; }

        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; } 
    }
}
