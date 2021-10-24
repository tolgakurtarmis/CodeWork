using CodeWork.Entities.Concrete;
using System.Collections.Generic;

namespace CodeWork.Dal.Abstract
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        List<Book> ListByFilter(string filter);

    }
}
