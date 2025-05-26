using BookStore.Server.Dtos.BookStore.Server.Models;
using BookStore.Server.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    /// <summary>
    /// API controller for managing and searching books.
    /// </summary>
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BooksController"/> class.
        /// </summary>
        /// <param name="bookService">The book service used for book operations.</param>
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Searches for books by author, ISBN, and ownership status, with pagination support.
        /// </summary>
        /// <param name="author">The author's first or last name to search for. Optional.</param>
        /// <param name="isbn">The ISBN to search for. Optional.</param>
        /// <param name="status">The ownership status to search for (e.g., "own", "love", "wanttoread"). Optional.</param>
        /// <param name="page">The page number for pagination (1-based). Defaults to 1.</param>
        /// <param name="pageSize">The number of items per page. Defaults to 10.</param>
        /// <returns>
        /// An <see cref="IActionResult"/> containing an object with the collection of books matching the search criteria for the specified page and the total count of matching books.
        /// </returns>
        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? author,
            [FromQuery] string? isbn,
            [FromQuery] string? status,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var (books, totalCount) = await _bookService.SearchBooksAsync(author, isbn, status, page, pageSize);

            var booksList = books.Select(b => new BookDto()
            {
                FirstName = b.FirstName,
                LastName = b.LastName,
                Isbn = b.Isbn,
                Title = b.Title,
                Type = b.Type,
                Category = b.Category,
                AvailableCopies = $"{b.CopiesInUse}/{b.TotalCopies}",
                Id = b.Id.ToString(),
                OwnershipStatus = b.OwnershipStatus.ToString(),
            });
            return Ok(new { Data = booksList, TotalCount = totalCount });
        }
    }
}
