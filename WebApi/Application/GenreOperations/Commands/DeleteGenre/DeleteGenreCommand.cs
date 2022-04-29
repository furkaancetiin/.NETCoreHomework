using System;
using System.Linq;
using WebApi.DBoperations;

namespace WebApi.Application.GenreOperations.Commands.DeleteGenre{
    public class DeleteGenreCommand{
        public int GenreId { get; set; }
        private readonly BookStoreDbContext _context;
        public DeleteGenreCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(g=>g.Id==GenreId);

            if(genre is null)
            throw new InvalidOperationException("Kitap türü bulunamamıştır.");

            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}