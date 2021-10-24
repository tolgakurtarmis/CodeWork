using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;

namespace CodeWork.Dal.Concrete.EntityFramework
{
    public class EfBookTransactionRepository : BaseRepository<BookTransaction, EFContext>, IBookTransactionRepository
    {
        public EfBookTransactionRepository(EFContext context) : base(context)
        {

        }
       
    }
}
