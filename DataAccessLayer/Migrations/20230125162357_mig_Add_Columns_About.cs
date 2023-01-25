using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_Add_Columns_About : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutImage2",
                table: "abouts",
                newName: "AboutPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "AboutImage1",
                table: "abouts",
                newName: "AboutImage");

            migrationBuilder.RenameColumn(
                name: "AboutDetails2",
                table: "abouts",
                newName: "AboutEmailAddress");

            migrationBuilder.AddColumn<string>(
                name: "AboutDetailShort",
                table: "abouts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutDetailShort",
                table: "abouts");

            migrationBuilder.RenameColumn(
                name: "AboutPhoneNumber",
                table: "abouts",
                newName: "AboutImage2");

            migrationBuilder.RenameColumn(
                name: "AboutImage",
                table: "abouts",
                newName: "AboutImage1");

            migrationBuilder.RenameColumn(
                name: "AboutEmailAddress",
                table: "abouts",
                newName: "AboutDetails2");
        }
    }
}
