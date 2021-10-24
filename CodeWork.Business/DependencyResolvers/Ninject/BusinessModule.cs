using AutoMapper;
using CodeWork.Business.Abstract;
using CodeWork.Business.Concrete.Manager;
using CodeWork.Business.Mapping;
using CodeWork.Dal.Abstract;
using CodeWork.Dal.Concrete.EntityFramework;
using Ninject.Modules;
using System.Data.Entity;

namespace CodeWork.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<EFContext>();

            Bind<IBookService>().To<BookService>();          
            Bind<IAuthorService>().To<AuthorService>();
            Bind<IImageService>().To<ImageService>();
            Bind<IMemberService>().To<MemberService>();
            Bind<IBookTransactionService>().To<BookTransactionService>();



            Bind<IBookRepository>().To<EfBookRepository>();
            Bind<IAuthorRepository>().To<EfAuthorRepository>();
            Bind<IImageRepository>().To<EfImageRepository>();
            Bind<IMemberRepository>().To<EfMemberRepository>();
            Bind<IBookTransactionRepository>().To<EfBookTransactionRepository>();


            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile<GeneralMapping>(); });
            this.Bind<IMapper>().ToConstructor(c => new Mapper(mapperConfiguration)).InSingletonScope();
            this.Bind<Root>().ToSelf().InSingletonScope();
             

        }
        public class Root
        {
            public Root(IMapper mapper)
            {
            }
        }

    }
}
