using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books_api.Data.Services;
using my_books_api.Data.ViewModels;

namespace my_books_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController_2 : ControllerBase
    {
        private BooksService_2 _booksService;
        public BooksController_2(BooksService_2 booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBookWithAuthors(BookVM_2 book)
        {
            try
            {
                _booksService.AddBookWithAuthors(book);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var _books = _booksService.GetAllBooks();
                return Ok(_books);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var _book = _booksService.GetBookById(id);
                return Ok(_book);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-books-by-author-id/{id}")]
        public IActionResult GetBookData(int id)
        {
            var response = _booksService.GetBooksByAuthor(id);
            return Ok(response);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id,[FromBody] BookVM_2 book)
        {
            try
            {
                var _book = _booksService.UpdateBookById(id, book);
                return Ok(_book);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            try
            {
                _booksService.DeleteBookById(id);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
