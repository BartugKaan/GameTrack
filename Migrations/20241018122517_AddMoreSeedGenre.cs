using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreSeedGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[] { 9, "MMO" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9);
        }
    }
}
