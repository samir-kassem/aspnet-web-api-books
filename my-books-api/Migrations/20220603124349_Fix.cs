using Microsoft.EntityFrameworkCore.Migrations;

namespace my_books_api.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_2_Publishers_2_Publisher_2Id",
                table: "Books_2");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_2_Authors_2_AuthorId",
                table: "Books_Authors_2");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_2_Books_2_BookId",
                table: "Books_Authors_2");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Books_2");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books_Authors_2",
                newName: "Book_2Id");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Books_Authors_2",
                newName: "Author_2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_2_BookId",
                table: "Books_Authors_2",
                newName: "IX_Books_Authors_2_Book_2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_2_AuthorId",
                table: "Books_Authors_2",
                newName: "IX_Books_Authors_2_Author_2Id");

            migrationBuilder.AlterColumn<int>(
                name: "Publisher_2Id",
                table: "Books_2",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_2_Publishers_2_Publisher_2Id",
                table: "Books_2",
                column: "Publisher_2Id",
                principalTable: "Publishers_2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_2_Authors_2_Author_2Id",
                table: "Books_Authors_2",
                column: "Author_2Id",
                principalTable: "Authors_2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_2_Books_2_Book_2Id",
                table: "Books_Authors_2",
                column: "Book_2Id",
                principalTable: "Books_2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_2_Publishers_2_Publisher_2Id",
                table: "Books_2");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_2_Authors_2_Author_2Id",
                table: "Books_Authors_2");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_2_Books_2_Book_2Id",
                table: "Books_Authors_2");

            migrationBuilder.RenameColumn(
                name: "Book_2Id",
                table: "Books_Authors_2",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "Author_2Id",
                table: "Books_Authors_2",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_2_Book_2Id",
                table: "Books_Authors_2",
                newName: "IX_Books_Authors_2_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_Authors_2_Author_2Id",
                table: "Books_Authors_2",
                newName: "IX_Books_Authors_2_AuthorId");

            migrationBuilder.AlterColumn<int>(
                name: "Publisher_2Id",
                table: "Books_2",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Books_2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_2_Publishers_2_Publisher_2Id",
                table: "Books_2",
                column: "Publisher_2Id",
                principalTable: "Publishers_2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_2_Authors_2_AuthorId",
                table: "Books_Authors_2",
                column: "AuthorId",
                principalTable: "Authors_2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_2_Books_2_BookId",
                table: "Books_Authors_2",
                column: "BookId",
                principalTable: "Books_2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
