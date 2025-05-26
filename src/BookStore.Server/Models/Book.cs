namespace BookStore.Server.Models
{
    /// <summary>
    /// Represents a book in the bookstore system.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets the unique identifier for the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the first name of the book's author.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the last name of the book's author.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the total number of copies available for the book.
        /// </summary>
        public int TotalCopies { get; set; } = 0;

        /// <summary>
        /// Gets or sets the number of copies currently in use (e.g., checked out).
        /// </summary>
        public int CopiesInUse { get; set; } = 0;

        /// <summary>
        /// Gets or sets the type of the book (e.g., Hardcover, Paperback, eBook).
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the International Standard Book Number (ISBN) of the book.
        /// </summary>
        public string Isbn { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category or genre of the book.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the ownership status of the book.
        /// </summary>
        public OwnershipStatus OwnershipStatus { get; set; }
    }
}
