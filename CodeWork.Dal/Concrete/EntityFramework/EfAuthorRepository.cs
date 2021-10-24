using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace CodeWork.Dal.Concrete.EntityFramework
{
    public class EfAuthorRepository : BaseRepository<BookAuthor, EFContext>, IAuthorRepository
    {
        public EfAuthorRepository(EFContext context) : base(context)
        {

        }

        public List<BookAuthor> ListByFilter(string filter)
        {
            EFContext context = new EFContext();
            var results = from i in context.BookAuthors where i.Name.Contains(filter) select i;

            return results.ToList();
        } 
    }
}
