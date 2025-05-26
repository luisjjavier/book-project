using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalCopies",
                table: "Books",
                newName: "total_copies");

            migrationBuilder.RenameColumn(
                name: "CopiesInUse",
                table: "Books",
                newName: "copies_in_use");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "total_copies",
                table: "Books",
                newName: "TotalCopies");

            migrationBuilder.RenameColumn(
                name: "copies_in_use",
                table: "Books",
                newName: "CopiesInUse");
        }
    }
}
