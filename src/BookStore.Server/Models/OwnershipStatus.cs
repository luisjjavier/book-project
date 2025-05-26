namespace BookStore.Server.Models
{
    /// <summary>
    /// Specifies the ownership status of a book for a user.
    /// </summary>
    public enum OwnershipStatus
    {
        /// <summary>
        /// The user owns the book.
        /// </summary>
        Own = 0,

        /// <summary>
        /// The user loves the book.
        /// </summary>
        Love = 1,

        /// <summary>
        /// The user wants to read the book.
        /// </summary>
        WantToRead = 2,
    }
}