using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.DeleteAuthor;
using WebApi.Application.AuthorOperations.Commands.GetAuthorById;
using WebApi.Application.AuthorOperations.Commands.Queries.GetAuthorById;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.DBoperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAuthors()
        {
            GetAuthorsQuery query = new GetAuthorsQuery(_context, _mapper);
            var obj = query.Handle();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public IActionResult GetAuthor(int id)
        {
            GetAuthorByIdQuery getAuthor = new GetAuthorByIdQuery(_context, _mapper);
            getAuthor.AuthorId = id;

            GetAuthorByIdQueryValidator validator = new GetAuthorByIdQueryValidator();
            validator.ValidateAndThrow(getAuthor);
            var obj = getAuthor.Handle();
            return Ok(obj);

        }

        [HttpPost()]
        public IActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor){

           CreateAuthorCommand command = new CreateAuthorCommand(_context,_mapper);
           command.Model = newAuthor;

           CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();
           validator.ValidateAndThrow(command);

           command.Handle();
           return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id , [FromBody] UpdateAuthorModel updateAuthor){

           UpdateAuthorCommand command = new UpdateAuthorCommand(_context,_mapper);
           command.AuthorId = id;
           command.Model=updateAuthor;

           UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();
           validator.ValidateAndThrow(command);

           command.Handle();
           return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id){
           DeleteAuthorCommand command = new DeleteAuthorCommand(_context);
           command.AuthorId = id;

           DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();
           validator.ValidateAndThrow(command);

           command.Handle();
           return Ok();
        }
    }
}