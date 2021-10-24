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
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;
        private readonly IMapper _mapper;


        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public Response<BookDto> Add(BookDto bookDto)
        {
            var newBook = _mapper.Map<Book>(bookDto);
            newBook.IsActive = true;

            bookDto.SearchText = bookDto.Title + "|" + bookDto.AuthorName;

            var book = _bookRepository.Add(newBook);

            return Response<BookDto>.Success(_mapper.Map<BookDto>(book), 200);
        }

        public Response<NoContent> Delete(int Id)
        {
            var getBook = _bookRepository.Get(x => x.Id == Id);

            if (getBook == null)
            {
                return Response<NoContent>.Fail("Book Not Found", 404);
            }

            _bookRepository.Delete(Id);

            return Response<NoContent>.Success(204);
        }

        public Response<BookDto> Get(Expression<Func<Book, bool>> expression = null, string include = "")
        {
            var book = _bookRepository.Get(expression, include);

            if (book == null)
            {
                return Response<BookDto>.Fail("Book Not Found", 404);

            }
            return Response<BookDto>.Success(_mapper.Map<BookDto>(book), 200);
        }

        public Response<List<BookDto>> List(Expression<Func<Book, bool>> expression = null)
        {
            var books = _bookRepository.List(expression);

            return Response<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(books), 200);

        }

        public Response<BookUpdateDto> Update(BookUpdateDto bookUpdateDto)
        {
            var newBook = _mapper.Map<Book>(bookUpdateDto);

            var result = _bookRepository.Get(x => x.Id == newBook.Id);

            if (result == null)
            {
                return Response<BookUpdateDto>.Fail("Book Not Found", 404);
            }

            var getBook = _bookRepository.Update(newBook);


            return Response<BookUpdateDto>.Success(_mapper.Map<BookUpdateDto>(getBook), 200);

        }

        public Response<BookUpdateDto> UpdateImageId(int bookId, int coverImageId)
        {

            var result = _bookRepository.Get(x => x.Id == bookId);

            if (result == null)
            {
                return Response<BookUpdateDto>.Fail("Book Not Found", 404);
            }

            result.CoverImageId = coverImageId;

            var getBook = _bookRepository.Update(result);

            return Response<BookUpdateDto>.Success(_mapper.Map<BookUpdateDto>(getBook), 200);

        }

        public Response<List<BookDto>> ListBookByFilter(string filter)
        {
            var books = _bookRepository.ListByFilter(filter);

            return Response<List<BookDto>>.Success(_mapper.Map<List<BookDto>>(books), 200);
        }
    }
}
