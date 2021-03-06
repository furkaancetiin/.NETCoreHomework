using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Commands.DeleteGenre;
using WebApi.Application.GenreOperations.Commands.UpdateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreById;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.DBoperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenresController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres(){
            GetGenresQuery query = new GetGenresQuery(_context,_mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenre(int id){
            GetGenreById getGenre = new GetGenreById(_context,_mapper);
            getGenre.GenreId = id;

            GetGenreByIdValidator validator = new GetGenreByIdValidator();
            validator.ValidateAndThrow(getGenre);
            var obj = getGenre.Handle();
            return Ok(obj);
        }

         [HttpPost()]
        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre){
           CreateGenreCommand command = new CreateGenreCommand(_context);
           command.Model = newGenre;

           CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
           validator.ValidateAndThrow(command);

           command.Handle();
           return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id , [FromBody] UpdateGenreModel updateGenre){
           UpdateGenreCommand command = new UpdateGenreCommand(_context);
           command.GenreId = id;
           command.Model=updateGenre;

           UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();
           validator.ValidateAndThrow(command);

           command.Handle();
           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id){
           DeleteGenreCommand command = new DeleteGenreCommand(_context);
           command.GenreId = id;

           DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
           validator.ValidateAndThrow(command);

           command.Handle();
           return Ok();
        }
    }
}