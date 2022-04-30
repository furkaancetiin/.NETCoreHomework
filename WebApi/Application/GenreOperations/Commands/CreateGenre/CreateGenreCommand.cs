using System;
using System.Linq;
using WebApi.DBoperations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands.CreateGenre{
    public class CreateGenreCommand{
        public CreateGenreModel Model { get; set; }
        private readonly IBookStoreDbContext _context;
        public CreateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(g=>g.Name==Model.Name);
            if (genre != null)
            throw new InvalidOperationException("Kitap türü zaten mevcuttur.");

            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }
}