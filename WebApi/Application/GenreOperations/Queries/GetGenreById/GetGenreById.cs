using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBoperations;

namespace WebApi.Application.GenreOperations.Queries.GetGenreById{
    public class GetGenreById{
        public int GenreId { get; set; }
        private readonly IBookStoreDbContext _context ;
        private readonly IMapper _mapper;
        public GetGenreById(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle(){
            var genre = _context.Genres.SingleOrDefault(g=>g.IsActive && g.Id==GenreId);

            if(genre == null)
                throw new InvalidOperationException("Kitap türü bulunamamıştır.");

             return _mapper.Map<GenreDetailViewModel>(genre);
           
        }
    }

    public class GenreDetailViewModel{
        public int Id { get; set; }
        public string Name { get; set; }
    }
}