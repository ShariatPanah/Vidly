using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NumberAvilableAddedToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InStock",
                table: "Movies",
                newName: "NumberInStock");

            migrationBuilder.AddColumn<int>(
                name: "NumberAvailable",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.Sql("UPDATE Movies SET NumberAvailable = NumberInStock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberAvailable",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "NumberInStock",
                table: "Movies",
                newName: "InStock");
        }
    }
}
