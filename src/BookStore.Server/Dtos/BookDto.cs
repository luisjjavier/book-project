namespace BookStore.Server.Dtos
{
    namespace BookStore.Server.Models
    {
        /// <summary>
        /// Represents a data transfer object (DTO) for a book, used in API responses.
        /// </summary>
        public class BookDto
        {
            /// <summary>
            /// Gets or sets the unique identifier for the book.
            /// </summary>
            public string Id { get; set; } = string.Empty;

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
            /// Gets or sets the International Standard Book Number (ISBN) of the book.
            /// </summary>
            public string Isbn { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the ownership status of the book.
            /// </summary>
            public string OwnershipStatus { get; set; } = string.Empty;

            /// <summary>
            /// Gets or sets the publisher of the book. Optional.
            /// </summary>
            public string? Publisher { get; set; }

            /// <summary>
            /// Gets or sets the type of the book (e.g., Hardcover, Paperback, eBook). Optional.
            /// </summary>
            public string? Type { get; set; }

            /// <summary>
            /// Gets or sets the category or genre of the book. Optional.
            /// </summary>
            public string? Category { get; set; }

            /// <summary>
            /// Gets or sets the number of available copies of the book. Optional.
            /// </summary>
            public string? AvailableCopies { get; set; }
        }
    }

}
