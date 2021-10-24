using CodeWork.Business.DependencyResolvers;
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
    public interface IBookService
    {
        Response<BookDto> Get(Expression<Func<Book, bool>> expression = null, string include = "");
        Response<List<BookDto>> List(Expression<Func<Book, bool>> expression = null);
        Response<BookDto> Add(BookDto bookDto);
        Response<BookUpdateDto> Update(BookUpdateDto bookUpdateDto);
        Response<NoContent> Delete(int id);
        Response<BookUpdateDto> UpdateImageId(int bookId, int coverImageId);
        Response<List<BookDto>> ListBookByFilter(string filter);

    }
}
