using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBookById;

namespace WebApi.Common{
    public class MappingProfile:Profile{
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,GetBookByIdModel>()
            .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()))
            .ForMember(dest=>dest.PublishDate,opt=>opt.MapFrom(src=>src.PublishDate.ToString("dd/MM/yyyy")));
            CreateMap<Book,BooksViewModel>().ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()));
        }
    }
}