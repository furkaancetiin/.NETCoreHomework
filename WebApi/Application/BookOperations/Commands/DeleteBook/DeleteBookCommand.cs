using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.DBoperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook{
    public class DeleteBookCommand{
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public void Handle(){
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Silenecek kitap bulunamamıştır.");

            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}
