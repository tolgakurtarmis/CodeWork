using CodeWork.Dal.Abstract;
using CodeWork.Entities.Concrete;

namespace CodeWork.Dal.Concrete.EntityFramework
{
    public class EfImageRepository : BaseRepository<Image, EFContext>, IImageRepository
    {
        public EfImageRepository(EFContext context) : base(context)
        {

        }
    }
}
