using CodeWork.Entities.Concrete;
using System.Collections.Generic;

namespace CodeWork.Dal.Abstract
{
    public interface IMemberRepository : IBaseRepository<Member>
    {
        List<Member> ListMemberByFilter(string filter);

    }
}
