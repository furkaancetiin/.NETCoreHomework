using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenres{
    public class GetGenresQuery{
        private readonly BookStoreDbContext _context ;
        private readonly IMapper _mapper;
        public GetGenresQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle(){
            var genres = _context.Genres.Where(g=>g.IsActive).OrderBy(g=>g.Id);
            List<GenresViewModel> genresModel = _mapper.Map<List<GenresViewModel>>(genres);

            return genresModel;
        }
    }

    public class GenresViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}