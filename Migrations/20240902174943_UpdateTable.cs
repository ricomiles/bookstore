using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "title",
                table: "book",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "book",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "genre",
                table: "book",
                newName: "Genre");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "book",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "book",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "book",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "book",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Genre",
                table: "book",
                newName: "genre");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "book",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "book",
                newName: "id");
        }
    }
}
