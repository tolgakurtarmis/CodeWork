﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities.Dtos
{
    public class MemberUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? ModifiedDateTime => DateTime.Now;
    }
}
