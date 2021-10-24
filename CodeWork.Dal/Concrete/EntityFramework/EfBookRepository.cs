using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Linq.SqlClient;
using System.Data.SqlClient;
using System.Linq;

namespace CodeWork.Dal.Concrete.EntityFramework
{
    public class EfBookRepository : BaseRepository<Book, EFContext>, IBookRepository
    {
        public EfBookRepository(EFContext context) : base(context)
        {

        }
        public List<Book> ListByFilter(string filter)
        {
            EFContext context = new EFContext();
            var results = context.Books.SqlQuery("select * from Books where SearchText like '%@filter%", new SqlParameter("@filter", filter)).ToList();

            return results.ToList();

        }
    }
}
