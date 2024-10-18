using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTrack.Migrations
{
    /// <inheritdoc />
    public partial class IdNameChangeforGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreNavigationId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "GenreNavigationId",
                table: "Games",
                newName: "GenreNavigationGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GenreNavigationId",
                table: "Games",
                newName: "IX_Games_GenreNavigationGenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreNavigationGenreId",
                table: "Games",
                column: "GenreNavigationGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreNavigationGenreId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenreNavigationGenreId",
                table: "Games",
                newName: "GenreNavigationId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_GenreNavigationGenreId",
                table: "Games",
                newName: "IX_Games_GenreNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreNavigationId",
                table: "Games",
                column: "GenreNavigationId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
