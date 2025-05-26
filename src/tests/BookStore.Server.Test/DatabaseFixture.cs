using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Server.DbContexts;
using BookStore.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Server.Test
{
    public class DatabaseFixture
    {
        public LibraryDbContext Context { get; private set; }
        public DatabaseFixture()
        {

            var options = new DbContextOptionsBuilder<LibraryDbContext>()
                .UseInMemoryDatabase(databaseName: "BookServiceTestDb")
                .Options;

            Context = new LibraryDbContext(options);
            Context.Books.AddRange(GetTestBooks());
            Context.SaveChanges();
        }
        private static List<Book> GetTestBooks() =>
            new()
            {
                new Book { Id = 1, Title = "C# in Depth", FirstName = "Jon", LastName = "Skeet", Isbn = "123", OwnershipStatus = OwnershipStatus.Own },
                new Book { Id = 2, Title = "CLR via C#", FirstName = "Jeffrey", LastName = "Richter", Isbn = "456", OwnershipStatus = OwnershipStatus.Love },
                new Book { Id = 3, Title = "Pro ASP.NET Core", FirstName = "Adam", LastName = "Freeman", Isbn = "789", OwnershipStatus = OwnershipStatus.WantToRead }
            };

    }
}
