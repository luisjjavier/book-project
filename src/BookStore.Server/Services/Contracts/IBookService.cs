using BookStore.Server.Models;

namespace BookStore.Server.Services.Contracts
{
    /// <summary>
    /// Defines the contract for book-related services, including searching and pagination.
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// Searches for books based on author name, ISBN, and ownership status, with support for pagination.
        /// </summary>
        /// <param name="author">The author's first or last name to search for. If null or whitespace, this filter is ignored.</param>
        /// <param name="isbn">The ISBN to search for. If null or whitespace, this filter is ignored.</param>
        /// <param name="status">The ownership status to search for (e.g., "own", "love", "wanttoread"). If null or whitespace, this filter is ignored.</param>
        /// <param name="page">The page number for pagination (1-based). Defaults to 1.</param>
        /// <param name="pageSize">The number of items per page. Defaults to 10.</param>
        /// <returns>
        /// A task that represents the asynchronous operation. The task result contains a tuple with:
        /// <list type="bullet">
        ///   <item>
        ///     <description><see cref="IEnumerable{Book}"/>: The collection of books matching the search criteria for the specified page.</description>
        ///   </item>
        ///   <item>
        ///     <description><see cref="int"/>: The total count of books matching the search criteria (for all pages).</description>
        ///   </item>
        /// </list>
        /// </returns>
        Task<(IEnumerable<Book> Books, int TotalCount)> SearchBooksAsync(
            string author,
            string isbn,
            string status,
            int page = 1,
            int pageSize = 10);
    }
}