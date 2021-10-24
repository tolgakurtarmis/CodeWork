using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Business.Abstract
{
    public interface IMemberService
    {
        Response<MemberDto> Get(Expression<Func<Member, bool>> expression = null, string include = "");
        Response<List<MemberDto>> List(Expression<Func<Member, bool>> expression = null);
        Response<MemberDto> Add(MemberCreateDto memberDto);
        Response<MemberUpdateDto> Update(MemberUpdateDto memberUpdateDto);
        Response<NoContent> Delete(int id);
        Response<List<MemberDto>> ListMemberByFilter(string filter);

    }
}
