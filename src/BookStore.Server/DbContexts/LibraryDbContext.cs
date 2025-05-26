using BookStore.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.DbContexts
{
    /// <summary>
    /// Represents the database context for the library application.
    /// </summary>
    public class LibraryDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryDbContext"/> class with the specified options.
        /// </summary>
        /// <param name="options"></param>
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of books in the library database.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Configures the model for the application database context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LibraryDbContext).Assembly);
        }
    }
}
