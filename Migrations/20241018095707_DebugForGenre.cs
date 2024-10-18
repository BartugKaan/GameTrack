using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameTrack.Migrations
{
    /// <inheritdoc />
    public partial class DebugForGenre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreNavigationGenreId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GenreNavigationGenreId",
                table: "Games",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreNavigationGenreId",
                table: "Games",
                column: "GenreNavigationGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Genres_GenreNavigationGenreId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "GenreNavigationGenreId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Genres_GenreNavigationGenreId",
                table: "Games",
                column: "GenreNavigationGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
