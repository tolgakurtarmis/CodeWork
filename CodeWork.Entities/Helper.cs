using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Entities
{
    public static class Helper
    {
        public static string Date(this DateTime dateTime)
        {
            return $"{dateTime:dd/MM/yyyy}";
        }
    }
}
