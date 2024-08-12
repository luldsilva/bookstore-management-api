using bookstore_management_api.Models;
using bookstore_management_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace bookstore_management_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IServiceBooks _serviceBooks;
        public BookController(IServiceBooks serviceBooks)
        {
            _serviceBooks = serviceBooks;
        }

        [HttpGet("list-all-books")]
        public async Task<ActionResult<IAsyncEnumerable<BookModels>>> GetAllBooks()
        {
            try
            {
                var allBooks = await _serviceBooks.GetAllBooks();
                return Ok(allBooks);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("book-register")]
        public async Task<ActionResult> CreateBook(BookModels book)
        {
            try
            {
                await _serviceBooks.BookRegister(book);
                return Created();
            }
            catch (Exception)
            {
                throw;
            }
        } 
        [HttpPut("book-update")]
        public async Task<ActionResult> UpdateBook([FromBody] BookModels book)
        {
            try
            {
                if (book.Id != 0)
                {
                    var result = await _serviceBooks.UpdateBook(book);

                    if (!result.Success)
                    {
                        return NotFound(result.Message);
                    }

                    return Ok("Success to update");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }

        [HttpDelete("book-delete/id:long")]
        public async Task<ActionResult> DeleteBook(long bookId)
        {
            try
            {
                var bookExisting = await _serviceBooks.GetBookById(bookId);
                if (bookExisting is not null)
                {
                    _serviceBooks.DeleteBook(bookExisting);

                    return Ok("Book has been excluded.");
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
            }
        }
    }
}
