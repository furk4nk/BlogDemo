using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_add_writer_by_counrty_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "writers",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "writers",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisctrictID",
                table: "writers",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "districtsDisctrictID",
                table: "writers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_writers_CityID",
                table: "writers",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_writers_CountryID",
                table: "writers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_writers_districtsDisctrictID",
                table: "writers",
                column: "districtsDisctrictID");

            migrationBuilder.AddForeignKey(
                name: "FK_writers_cities_CityID",
                table: "writers",
                column: "CityID",
                principalTable: "cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_countries_CountryID",
                table: "writers",
                column: "CountryID",
                principalTable: "countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_districts_districtsDisctrictID",
                table: "writers",
                column: "districtsDisctrictID",
                principalTable: "districts",
                principalColumn: "DisctrictID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_writers_cities_CityID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_countries_CountryID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_districts_districtsDisctrictID",
                table: "writers");

            migrationBuilder.DropIndex(
                name: "IX_writers_CityID",
                table: "writers");

            migrationBuilder.DropIndex(
                name: "IX_writers_CountryID",
                table: "writers");

            migrationBuilder.DropIndex(
                name: "IX_writers_districtsDisctrictID",
                table: "writers");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "writers");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "writers");

            migrationBuilder.DropColumn(
                name: "DisctrictID",
                table: "writers");

            migrationBuilder.DropColumn(
                name: "districtsDisctrictID",
                table: "writers");
        }
    }
}
