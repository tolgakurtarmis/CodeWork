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
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public Response<BookAuthorDto> Add(BookAuthorCreateDto bookDto)
        {
            throw new NotImplementedException();
        }

        public Response<NoContent> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Response<BookAuthorDto> Get(Expression<Func<BookAuthorDto, bool>> expression = null, string include = "")
        {
            throw new NotImplementedException();
        }

        public Response<List<BookAuthorDto>> List(Expression<Func<BookAuthor, bool>> expression = null)
        {

            var authors = _authorRepository.List(expression);

            return Response<List<BookAuthorDto>>.Success(_mapper.Map<List<BookAuthorDto>>(authors), 200);
        }

        public Response<BookUpdateDto> Update(BookAuthorUpdateDto bookUpdateDto)
        {
            throw new NotImplementedException();
        }

        public Response<List<BookAuthorDto>> ListByFilter(string filter)
        {
            var authors = _authorRepository.ListByFilter(filter);

            return Response<List<BookAuthorDto>>.Success(_mapper.Map<List<BookAuthorDto>>(authors), 200);
        }
    }
}
