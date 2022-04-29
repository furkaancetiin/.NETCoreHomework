using AutoMapper;
using System;
using WebApi.Entities;
using WebApi.Application.BookOperations.Commands.CreateBook;
using WebApi.Application.Queries.GetBookById;
using WebApi.Application.Queries.GetBooks;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.Application.GenreOperations.Queries.GetGenreById;
using WebApi.Application.AuthorOperations.Commands.Queries.GetAuthorById;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;

namespace WebApi.Common{
    public class MappingProfile:Profile{
        public MappingProfile()
        {
            CreateMap<CreateBookModel,Book>();
            CreateMap<Book,GetBookByIdModel>()
            .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.PublishDate,opt=>opt.MapFrom(src=>src.PublishDate.ToString("dd/MM/yyyy")))
            .ForMember(dest=>dest.AuthorFirstName,opt=>opt.MapFrom(src=>src.Author.FirstName))
            .ForMember(dest=>dest.AuthorLastName,opt=>opt.MapFrom(src=>src.Author.LastName));
            CreateMap<Book,BooksViewModel>()
            .ForMember(dest=>dest.PublishDate,opt=>opt.MapFrom(src=>src.PublishDate.ToString("dd/MM/yyyy")))
            .ForMember(dest=>dest.Genre,opt=>opt.MapFrom(src=>src.Genre.Name))
            .ForMember(dest=>dest.AuthorFirstName,opt=>opt.MapFrom(src=>src.Author.FirstName))
            .ForMember(dest=>dest.AuthorLastName,opt=>opt.MapFrom(src=>src.Author.LastName));
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<Author,AuthorDetailViewModel>()
            .ForMember(dest=>dest.DateOfBirth,opt=>opt.MapFrom(src=>src.DateOfBirth.ToString("dd/MM/yyyy")));
            CreateMap<Author,AuthorsViewModel>()
            .ForMember(dest=>dest.DateOfBirth,opt=>opt.MapFrom(src=>src.DateOfBirth.ToString("dd/MM/yyyy")));
            CreateMap<CreateAuthorModel,Author>()
            .ForMember(dest=>dest.DateOfBirth,opt=>opt.MapFrom(src=>Convert.ToDateTime(src.DateOfBirth)));
            CreateMap<UpdateAuthorModel,Author>()
            .ForMember(dest=>dest.DateOfBirth,opt=>opt.MapFrom(src=>Convert.ToDateTime(src.DateOfBirth)));
           
        }
    }
}