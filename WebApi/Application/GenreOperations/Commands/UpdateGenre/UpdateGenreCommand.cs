using System;
using System.Linq;
using WebApi.DBoperations;

namespace WebApi.Application.GenreOperations.Commands.UpdateGenre{
    public class UpdateGenreCommand{
        public int GenreId { get; set; }
        public UpdateGenreModel Model{get;set;}
        private readonly IBookStoreDbContext _context;
        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle(){
            var genre = _context.Genres.SingleOrDefault(g=>g.Id==GenreId);
            if (genre == null)
            throw new InvalidOperationException("Kitap türü zaten mevcuttur.");

           if(_context.Genres.Any(g=>g.Name.ToLower()==Model.Name.ToLower() && g.Id!=GenreId))
           throw new InvalidOperationException("Aynı isimli kitap türü zaten mevcuttur.");

            genre.Name = String.IsNullOrEmpty( Model.Name.Trim())  ? genre.Name : Model.Name;
            genre.IsActive =Model.IsActive;   

            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive {get;set;} = true;
    }
}