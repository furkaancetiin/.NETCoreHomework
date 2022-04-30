using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.Application.Queries.GetBookById{

    public class GetBookById
    {
        private readonly IBookStoreDbContext _dbContext;   
        private readonly IMapper _mapper;   
        public int BookId {get;set;}
        public GetBookById(IBookStoreDbContext dbContext,IMapper mapper)
        {
           _dbContext=dbContext;
           _mapper=mapper;
        }

        public GetBookByIdModel Handle()
        {
            var book = _dbContext.Books.Include(b=>b.Genre).Include(b=>b.Author).SingleOrDefault(b => b.Id == BookId);
            
            if(book is null)
            throw new InvalidOperationException("Böyle bir kitap bulunmamaktadır.");

            GetBookByIdModel getBookByIdModel = _mapper.Map<GetBookByIdModel>(book); //new GetBookByIdModel();

            // getBookByIdModel.Genre=((GenreEnum)book.GenreId).ToString();
            // getBookByIdModel.PageCount=book.PageCount;
            // getBookByIdModel.Title=book.Title;
            // getBookByIdModel.PublishDate=book.PublishDate.ToString("dd/MM/yyyy");       
            
            return getBookByIdModel;  

        }
    }

    public class GetBookByIdModel
    {
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string Title { get; set; }
        public string PublishDate { get; set; }
        public string AuthorFirstName {get;set;}
        public string AuthorLastName {get;set;}
    }
}
