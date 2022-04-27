using System;
using System.Linq;
using WebApi.Common;
using WebApi.DBoperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel updateBookModel { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle(int id)
        {            
            var book = _dbContext.Books.SingleOrDefault(b => b.Id == id);

            if (book is null)
            { throw new InvalidOperationException("Böyle bir kitap bulunmamaktadır."); }          


           if(Enum.IsDefined(typeof(GenreEnum),updateBookModel.Genre)){
            var enumBookModel=Enum.Parse<GenreEnum>(updateBookModel.Genre); 
           var updateBookModelGenreId = Convert.ToInt32(enumBookModel);  
           book.GenreId = updateBookModel.Genre != default ? updateBookModelGenreId : book.GenreId;
           }else{
               throw new InvalidOperationException("Böyle bir tür bulunmamaktadır.");
           }                        
           
            book.PageCount = updateBookModel.PageCount != default ? updateBookModel.PageCount : book.PageCount;
            book.PublishDate = updateBookModel.PublishDate != default ? Convert.ToDateTime(updateBookModel.PublishDate) : book.PublishDate;
            book.Title = updateBookModel.Title != default ? updateBookModel.Title : book.Title;

            _dbContext.SaveChanges();
        }
    }

    public class UpdateBookModel
    {        
       
        public string Genre { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}