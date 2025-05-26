using BookStore.Server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string author, [FromQuery] string isbn, [FromQuery] string status)
        {
            var books = await _bookService.SearchBooksAsync(author, isbn, status);
            return Ok(books);
        }
    }
}
