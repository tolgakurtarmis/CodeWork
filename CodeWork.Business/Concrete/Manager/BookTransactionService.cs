using AutoMapper;
using CodeWork.Business.Abstract;
using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodeWork.Business.Concrete.Manager
{
    public class BookTransactionService : IBookTransactionService
    {
        private IBookTransactionRepository _bookTransactionRepository;
        private readonly IMapper _mapper;

        public BookTransactionService(IBookTransactionRepository bookTransactionRepository, IMapper mapper)
        {
            _bookTransactionRepository = bookTransactionRepository;
            _mapper = mapper;
        }


        public Response<BookTransactionDto> Add(BookTransactionCreateDto bookTransactionCreateDto)
        {
            var newBookTransactionService = _mapper.Map<BookTransaction>(bookTransactionCreateDto);
            var member = _bookTransactionRepository.Add(newBookTransactionService);

            return Response<BookTransactionDto>.Success(_mapper.Map<BookTransactionDto>(member), 200);
        }

        public Response<NoContent> Delete(int id)
        {
            var getBookTransaction = _bookTransactionRepository.Get(x => x.Id == id);

            if (getBookTransaction == null)
            {
                return Response<NoContent>.Fail("Book Transaction Not Found", 404);
            }

            _bookTransactionRepository.Delete(id);

            return Response<NoContent>.Success(204);
        }

        public Response<BookTransactionDto> Get(Expression<Func<BookTransaction, bool>> expression = null, string include = "")
        {
            var bookTransaction = _bookTransactionRepository.Get(expression, include);

            if (bookTransaction == null)
            {
                return Response<BookTransactionDto>.Fail("Book Transaction Not Found", 404);

            }
            return Response<BookTransactionDto>.Success(_mapper.Map<BookTransactionDto>(bookTransaction), 200);
        }

        public Response<List<BookTransactionDto>> List(Expression<Func<BookTransaction, bool>> expression = null)
        {
            var members = _bookTransactionRepository.List(expression);

            return Response<List<BookTransactionDto>>.Success(_mapper.Map<List<BookTransactionDto>>(members), 200);
        }

        public Response<BookTransactionUpdateDto> Update(BookTransactionUpdateDto bookTransactionUpdateDto)
        {
            var newBookTransaction = _mapper.Map<BookTransaction>(bookTransactionUpdateDto);

            var result = _bookTransactionRepository.Get(x => x.Id == newBookTransaction.Id);

            if (result == null)
            {
                return Response<BookTransactionUpdateDto>.Fail("Book Transaction Not Found", 404);
            }
            newBookTransaction.AddedDate = result.AddedDate;

            var getBookTransaction = _bookTransactionRepository.Update(newBookTransaction);


            return Response<BookTransactionUpdateDto>.Success(_mapper.Map<BookTransactionUpdateDto>(getBookTransaction), 200);

        }
    }
}
