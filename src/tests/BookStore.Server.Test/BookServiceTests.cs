using BookStore.Server.Models;
using BookStore.Server.Services;

namespace BookStore.Server.Test
{
    public class BookServiceTests: IClassFixture<DatabaseFixture>
    {
        DatabaseFixture fixture;

        public BookServiceTests(DatabaseFixture databaseFixture)
        {
            fixture = databaseFixture;

        }

        [Fact]
        public async Task SearchBooksAsync_ReturnsBooksByAuthor()
        {
            // Arrange
            var context = fixture.Context;
            var service = new BookService(context);

            // Act
            var (books, totalCount) = await service.SearchBooksAsync("Jon", null, null, 1, 10);

            // Assert
            Assert.Single(books);
            Assert.Equal(1, totalCount);
            Assert.Contains(books, b => b.FirstName == "Jon");
        }

        [Fact]
        public async Task SearchBooksAsync_ReturnsBooksByIsbn()
        {
            // Arrange
            var context = fixture.Context;
            var service = new BookService(context);

            // Act
            var (books, totalCount) = await service.SearchBooksAsync(null, "456", null, 1, 10);

            // Assert
            Assert.Single(books);
            Assert.Equal(1, totalCount);
            Assert.Contains(books, b => b.Isbn == "456");
        }

        [Fact]
        public async Task SearchBooksAsync_ReturnsBooksByStatus()
        {
            // Arrange
            var context = fixture.Context;
            var service = new BookService(context);

            // Act
            var (books, totalCount) = await service.SearchBooksAsync(null, null, "love", 1, 10);

            // Assert
            Assert.Single(books);
            Assert.Equal(1, totalCount);
            Assert.Contains(books, b => b.OwnershipStatus == OwnershipStatus.Love);
        }

        [Fact]
        public async Task SearchBooksAsync_ReturnsAllBooks_WhenNoFilter()
        {
            // Arrange
            var context = fixture.Context;
            var service = new BookService(context);

            // Act
            var (books, totalCount) = await service.SearchBooksAsync(null, null, null, 1, 10);

            // Assert
            Assert.Equal(3, books.Count());
            Assert.Equal(3, totalCount);
        }

        [Fact]
        public async Task SearchBooksAsync_PaginatesResults()
        {
            // Arrange
            var context = fixture.Context;
            var service = new BookService(context);

            // Act
            var (books, totalCount) = await service.SearchBooksAsync(null, null, null, 2, 2);

            // Assert
            Assert.Single(books); // Only 1 book on page 2 (3 total, 2 per page)
            Assert.Equal(3, totalCount);
        }
    }
}
