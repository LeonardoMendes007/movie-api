using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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

            migrationBuilder.InsertData(
                table: "tb_genre",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("096fef1e-046a-40e4-901b-ab5df10dc52d"), "Comédia romântica" },
                    { new Guid("22c86897-6f3d-46b2-877f-49173dddd1c1"), "Comédia de ação" },
                    { new Guid("333367b7-c969-4150-92cf-d7ee2407e3f2"), "Guerra" },
                    { new Guid("39851f71-7ef8-47ea-ad50-d47a00106e9b"), "Drama" },
                    { new Guid("482d67d9-7ff9-4d0d-beb2-0dfe411a825d"), "Comédia de terror" },
                    { new Guid("510a637c-51a3-4577-82f3-4f16c231a85b"), "Mistério" },
                    { new Guid("5122d77e-6838-426a-8296-f6d4b58567e7"), "Chanchada" },
                    { new Guid("558b4e2e-925a-454c-bb02-8d29bdabf756"), "Policial" },
                    { new Guid("593e4d44-fa19-440f-b817-d27073161066"), "Dança" },
                    { new Guid("63f6754b-5d74-4927-a19c-d8c127fd3e5b"), "Espionagem" },
                    { new Guid("6cfad5a0-47dc-431d-8a31-6b5e2eae8f8a"), "Cinema de arte" },
                    { new Guid("812c80b1-bfec-487f-ad92-3071ba741d72"), "Ficção científica" },
                    { new Guid("84c9eb1a-0374-491f-8f7f-fee2587ae01a"), "Thriller" },
                    { new Guid("898fadcb-7921-488a-9522-0e38b1495cb6"), "Terror" },
                    { new Guid("9b24adc8-3041-4f22-bb5b-1ea23d53435c"), "Romance" },
                    { new Guid("a19b4d55-facd-4f70-9528-80c340121652"), "Fantasia" },
                    { new Guid("a39b92db-d3ab-4aac-a573-12c055462886"), "Fantasia científica" },
                    { new Guid("a5f4ea06-7186-427c-918d-86484fa9b1f8"), "Filmes com truques" },
                    { new Guid("ad25b3fd-2aeb-4bee-b892-116b8737f16d"), "Faroeste" },
                    { new Guid("b59b8886-f2ff-4ba6-9a5a-fa9194f672bc"), "Docuficção" },
                    { new Guid("b8dee7ca-0f3a-4e3c-a547-3b73e7546a8e"), "Documentário" },
                    { new Guid("b9b2a60f-7a49-406e-b915-33572ffe826d"), "Musical" },
                    { new Guid("bec2a112-69ce-4811-b346-27bdc742dd63"), "Aventura" },
                    { new Guid("c1a7dc12-edb9-47d1-8cbd-b84337f8c25d"), "Comédia" },
                    { new Guid("ef328301-3f88-4c38-895c-955fdc6c0d85"), "Ação" },
                    { new Guid("f8a5ea89-9c47-4ed7-b9dc-2944e84ea0a1"), "Comédia dramática" }
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
