using AutoMapper;
using CodeWork.Entities.Concrete;
using CodeWork.Entities.Dtos;

namespace CodeWork.Business.Mapping
{
    public class GeneralMapping : Profile
    {     
        public GeneralMapping()
        {
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<BookAuthor, BookAuthorDto>().ReverseMap();
            CreateMap<BookAuthor, BookAuthorCreateDto>().ReverseMap();
            CreateMap<BookAuthor, BookAuthorUpdateDto>().ReverseMap();

            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Member, MemberCreateDto>().ReverseMap();
            CreateMap<Member, MemberUpdateDto>().ReverseMap();

            CreateMap<Image, ImageDto>().ReverseMap();
            CreateMap<Image, ImageCreateDto>().ReverseMap();
            CreateMap<Image, ImageUpdateDto>().ReverseMap();


            CreateMap<BookTransaction, BookTransactionDto>().ReverseMap();
            CreateMap<BookTransaction, BookTransactionCreateDto>().ReverseMap();
            CreateMap<BookTransaction, BookTransactionUpdateDto>().ReverseMap();

        }

    }
}
