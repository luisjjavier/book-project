using BookStore.Server.DbContexts;
using BookStore.Server.Models;
using BookStore.Server.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Services
{
    /// <summary>
    /// Provides services for managing and searching books in the library database.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class with the specified database context.
        /// </summary>
        /// <param name="context">The database context to be used for book operations.</param>
        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Searches for books based on author name, ISBN, and ownership status.
        /// </summary>
        /// <param name="author">The author's first or last name to search for. If null or whitespace, this filter is ignored.</param>
        /// <param name="isbn">The ISBN to search for. If null or whitespace, this filter is ignored.</param>
        /// <param name="status">The ownership status to search for (e.g., "own", "love", "wanttoread"). If null or whitespace, this filter is ignored.</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains an enumerable collection of books matching the search criteria.
        /// </returns>
        public async Task<(IEnumerable<Book> Books, int TotalCount)> SearchBooksAsync(string author, string isbn, string status, int page = 1, int pageSize = 10)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(author))
                query = query.Where(b => (b.FirstName + " " + b.LastName).Contains(author));

            if (!string.IsNullOrWhiteSpace(isbn))
                query = query.Where(b => b.Isbn.Contains(isbn));

            if (!string.IsNullOrWhiteSpace(status))
                query = query.Where(b => b.OwnershipStatus.ToString().ToLower().Contains(status.ToLower()));

            var totalCount = await query.CountAsync();

            var books = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (books, totalCount);
        }
    }
}
