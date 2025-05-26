using BookStore.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Server.DbContexts.ModelsConfiguration
{
    /// <summary>
    /// Configures the EF Core mapping for the <see cref="Book"/> entity.
    /// </summary>
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        /// <summary>
        /// Configures the properties and relationships of the <see cref="Book"/> entity.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Table mapping
            builder.ToTable("Books");

            // Primary key
            builder.HasKey(b => b.Id);

            // Id property configuration
            builder.Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("book_id")
                .IsRequired();

            // Title property configuration
            builder.Property(b => b.Title)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .HasColumnName("title")
                .IsRequired();

            // FirstName property configuration
            builder.Property(b => b.FirstName)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasColumnName("first_name")
                .IsRequired();

            // LastName property configuration
            builder.Property(b => b.LastName)
                .HasMaxLength(50)
                .HasColumnType("varchar(50)")
                .HasColumnName("last_name")
                .IsRequired();

            // Type property configuration
            builder.Property(b => b.Type)
                .HasMaxLength(50)
                .HasColumnName("type")
                .HasColumnType("varchar(50)");

            // ISBN property configuration
            builder.Property(b => b.Isbn)
                .HasMaxLength(80)
                .HasColumnName("isbn")
                .HasColumnType("varchar(80)");

            // Category property configuration
            builder.Property(b => b.Category)
                .HasMaxLength(50)
                .HasColumnName("category")
                .HasColumnType("varchar(50)");

            // OwnershipStatus property configuration
            builder.Property(b => b.OwnershipStatus)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            // TotalCopies and CopiesInUse property configuration
            builder.Property(b => b.TotalCopies)
                .HasColumnName("total_copies");

            // CopiesInUse property configuration
            builder.Property(b => b.CopiesInUse)
                .HasColumnName("copies_in_use");
        }
    }
}
