using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.GetById{

    public class GetBookById
    {
        private readonly BookStoreDbContext _dbContext;      
        public GetBookById(BookStoreDbContext dbContext)
        {
           _dbContext=dbContext;
        }

        public GetBookByIdModel Handle(int id)
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);
            
            if(book is null)
            throw new InvalidOperationException("Böyle bir kitap bulunmamaktadır.");

            GetBookByIdModel getBookByIdModel = new GetBookByIdModel();

            getBookByIdModel.Genre=((GenreEnum)book.GenreId).ToString();
            getBookByIdModel.PageCount=book.PageCount;
            getBookByIdModel.Title=book.Title;
            getBookByIdModel.PublishDate=book.PublishDate.ToString("dd/MM/yyyy");       
            
            return getBookByIdModel;  

        }
    }

    public class GetBookByIdModel
    {
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string Title { get; set; }
        public string PublishDate { get; set; }
    }
}
