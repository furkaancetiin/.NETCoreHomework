using System;
using System.Linq;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.Application.Commands.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel updateBookModel { get; set; }
        public int BookId { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == BookId);

            if (book is null)
            { throw new InvalidOperationException("Böyle bir kitap bulunmamaktadır."); }

            book.GenreId = updateBookModel.GenreId != default ? updateBookModel.GenreId : book.GenreId;
            book.PageCount = updateBookModel.PageCount != default ? updateBookModel.PageCount : book.PageCount;
            book.PublishDate = updateBookModel.PublishDate != default ? Convert.ToDateTime(updateBookModel.PublishDate) : book.PublishDate;
            book.Title = updateBookModel.Title != default ? updateBookModel.Title : book.Title;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {

        public int GenreId { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}