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
    public interface IBookTransactionService
    {
        Response<BookTransactionDto> Get(Expression<Func<BookTransaction, bool>> expression = null, string include = "");
        Response<List<BookTransactionDto>> List(Expression<Func<BookTransaction, bool>> expression = null);
        Response<BookTransactionDto> Add(BookTransactionCreateDto  bookTransactionCreateDto);
        Response<BookTransactionUpdateDto> Update(BookTransactionUpdateDto bookTransactionUpdateDto);
        Response<NoContent> Delete(int id);
    }
}
