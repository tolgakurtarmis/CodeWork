using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime AddedDate { get; set; }
        DateTime? ModifiedDateTime { get; set; }

    }
}
