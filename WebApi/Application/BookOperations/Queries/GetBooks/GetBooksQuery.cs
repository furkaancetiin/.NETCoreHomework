using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.Queries.GetBooks{
    public class GetBooksQuery{

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle(){
            var bookList = _dbContext.Books.Include(b=>b.Genre).Include(b=>b.Author).OrderBy(b => b.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);
         
            return vm;
        }
    }

    public class BooksViewModel{
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        public string AuthorFirstName {get;set;}
        public string AuthorLastName {get;set;}
    }
}