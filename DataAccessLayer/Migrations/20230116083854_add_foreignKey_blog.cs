using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class add_foreignKey_blog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogID",
                table: "comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_BlogID",
                table: "comments",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_CategoryID",
                table: "blogs",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_categories_CategoryID",
                table: "blogs",
                column: "CategoryID",
                principalTable: "categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_comments_blogs_BlogID",
                table: "comments",
                column: "BlogID",
                principalTable: "blogs",
                principalColumn: "BlogID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_categories_CategoryID",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_comments_blogs_BlogID",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_BlogID",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_blogs_CategoryID",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "BlogID",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "blogs");
        }
    }
}
