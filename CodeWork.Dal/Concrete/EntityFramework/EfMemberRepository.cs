using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Dal.Concrete.EntityFramework
{
    public class EfMemberRepository : BaseRepository<Member, EFContext>, IMemberRepository
    {
        public EfMemberRepository(EFContext context) : base(context)
        {

        }
        
        public List<Member> ListMemberByFilter(string filter)
        {
            EFContext context = new EFContext();
            var results = from i in context.Members where i.Name.Contains(filter) select i;

            return results.ToList();

        }
    }
}
