using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDateTime { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public string TCNo { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
        public string RegisteredDateTimeFormattedDateTime => AddedDate.Date();

        public string NameSurname => ToString();

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
