using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books_api.Migrations
{
    public partial class Recap_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors_2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers_2", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    DateRead = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Rate = table.Column<int>(type: "int", nullable: true),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    Publisher_2Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_2_Publishers_2_Publisher_2Id",
                        column: x => x.Publisher_2Id,
                        principalTable: "Publishers_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books_Authors_2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books_Authors_2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_2_Authors_2_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Authors_2_Books_2_BookId",
                        column: x => x.BookId,
                        principalTable: "Books_2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_2_Publisher_2Id",
                table: "Books_2",
                column: "Publisher_2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authors_2_AuthorId",
                table: "Books_Authors_2",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Authors_2_BookId",
                table: "Books_Authors_2",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books_Authors_2");

            migrationBuilder.DropTable(
                name: "Authors_2");

            migrationBuilder.DropTable(
                name: "Books_2");

            migrationBuilder.DropTable(
                name: "Publishers_2");
        }
    }
}
