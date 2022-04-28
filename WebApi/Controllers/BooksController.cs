using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.DeleteBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetBookById;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBoperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BooksController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooksById(int id)
        {
            GetBookByIdModel result;
            
            try
            {
                GetBookById getBookById = new GetBookById(_context,_mapper);
                getBookById.BookId=id;
                GetBookByIdValidator validator = new GetBookByIdValidator();
                validator.ValidateAndThrow(getBookById);
                result = getBookById.Handle();
               
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }          

             return Ok(result);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel addBookModel)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
            try
            {
                command.Model = addBookModel;

                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);             

                command.Handle();
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

            return Ok();
        }
        //FromRoute
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand updateBookCommand = new UpdateBookCommand(_context);
            try
            {
                updateBookCommand.BookId=id;
                updateBookCommand.updateBookModel = updatedBook;
                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(updateBookCommand);

                updateBookCommand.Handle();
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            try
            {
                command.BookId=id;
                DeleteBookCommandValidator validator = new DeleteBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
                
            }
            return Ok();

        }
    }
}