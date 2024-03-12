using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_genre",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genre", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_movie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    synopsis = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    dt_release = table.Column<DateTime>(type: "datetime2", nullable: false),
                    views = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    dt_create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_movie", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_genre_movie",
                columns: table => new
                {
                    GenriesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_genre_movie", x => new { x.GenriesId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_tb_genre_movie_tb_genre_GenriesId",
                        column: x => x.GenriesId,
                        principalTable: "tb_genre",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_genre_movie_tb_movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "tb_movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_favorites_movies",
                columns: table => new
                {
                    FavoritesMoviesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavoritesUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_favorites_movies", x => new { x.FavoritesMoviesId, x.FavoritesUsersId });
                    table.ForeignKey(
                        name: "FK_tb_favorites_movies_tb_movie_FavoritesMoviesId",
                        column: x => x.FavoritesMoviesId,
                        principalTable: "tb_movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_favorites_movies_tb_user_FavoritesUsersId",
                        column: x => x.FavoritesUsersId,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_rating",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<Guid>(type: "uniqueidentifier", maxLength: 36, nullable: false),
                    score = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dt_create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_rating", x => new { x.UserId, x.id });
                    table.ForeignKey(
                        name: "FK_tb_rating_tb_movie_id",
                        column: x => x.id,
                        principalTable: "tb_movie",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_rating_tb_user_UserId",
                        column: x => x.UserId,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_favorites_movies_FavoritesUsersId",
                table: "tb_favorites_movies",
                column: "FavoritesUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_genre_name",
                table: "tb_genre",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_genre_movie_MoviesId",
                table: "tb_genre_movie",
                column: "MoviesId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_movie_name_dt_release",
                table: "tb_movie",
                columns: new[] { "name", "dt_release" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_rating_id",
                table: "tb_rating",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_favorites_movies");

            migrationBuilder.DropTable(
                name: "tb_genre_movie");

            migrationBuilder.DropTable(
                name: "tb_rating");

            migrationBuilder.DropTable(
                name: "tb_genre");

            migrationBuilder.DropTable(
                name: "tb_movie");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
