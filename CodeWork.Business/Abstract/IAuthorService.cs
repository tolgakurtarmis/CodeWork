using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CodeWork.Business.Abstract
{
    public interface IAuthorService
    {
        Response<BookAuthorDto> Get(Expression<Func<BookAuthorDto, bool>> expression = null, string include = "");
        Response<List<BookAuthorDto>> List(Expression<Func<BookAuthor, bool>> expression = null);
        Response<BookAuthorDto> Add(BookAuthorCreateDto bookDto);
        Response<BookUpdateDto> Update(BookAuthorUpdateDto bookUpdateDto);
        Response<NoContent> Delete(int id);

        Response<List<BookAuthorDto>> ListByFilter(string filter);


    }
}
