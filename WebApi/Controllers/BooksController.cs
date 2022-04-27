using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.BookOperations.GetById;
using WebApi.BookOperations.UpdateBook;
using WebApi.DBoperations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BooksController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBooksById(int id)
        {
            GetBookById getBookById = new GetBookById(_context);

            try
            {
                var result = getBookById.Handle(id);
                return Ok(result);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }

            


        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel addBookModel)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = addBookModel;
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
                updateBookCommand.updateBookModel = updatedBook;
                updateBookCommand.Handle(id);
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
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book is null)
                return BadRequest();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();

        }
    }
}