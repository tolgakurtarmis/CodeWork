using AutoMapper;
using CodeWork.Business.Abstract;
using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeWork.Business.Concrete.Manager
{
    public class MemberService : IMemberService
    {
        private IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public Response<MemberDto> Add(MemberCreateDto memberDto)
        {
            var newMember = _mapper.Map<Member>(memberDto);
            var member = _memberRepository.Add(newMember);

            return Response<MemberDto>.Success(_mapper.Map<MemberDto>(member), 200);
        }

        public Response<NoContent> Delete(int id)
        {
            var getBook = _memberRepository.Get(x => x.Id == id);

            if (getBook == null)
            {
                return Response<NoContent>.Fail("Member Not Found", 404);
            }

            _memberRepository.Delete(id);

            return Response<NoContent>.Success(204);
        }
        public Response<MemberDto> Get(Expression<Func<Member, bool>> expression = null, string include = "")
        {
            var member = _memberRepository.Get(expression, include);

            if (member == null)
            {
                return Response<MemberDto>.Fail("Member Not Found", 404);

            }
            return Response<MemberDto>.Success(_mapper.Map<MemberDto>(member), 200);
        }

        public Response<List<MemberDto>> List(Expression<Func<Member, bool>> expression = null)
        {
            var members = _memberRepository.List(expression);

            return Response<List<MemberDto>>.Success(_mapper.Map<List<MemberDto>>(members), 200);

        }

        public Response<MemberUpdateDto> Update(MemberUpdateDto memberUpdateDto)
        {
            var newMember = _mapper.Map<Member>(memberUpdateDto);

            var result = _memberRepository.Get(x => x.Id == newMember.Id);

            if (result == null)
            {
                return Response<MemberUpdateDto>.Fail("Member Not Found", 404);
            }
            newMember.AddedDate = result.AddedDate;
            
            var getMember = _memberRepository.Update(newMember);


            return Response<MemberUpdateDto>.Success(_mapper.Map<MemberUpdateDto>(getMember), 200);

        }

        public Response<List<MemberDto>> ListMemberByFilter(string filter)
        {
            var members = _memberRepository.ListMemberByFilter(filter);

            return Response<List<MemberDto>>.Success(_mapper.Map<List<MemberDto>>(members), 200);
        }
    }
}
