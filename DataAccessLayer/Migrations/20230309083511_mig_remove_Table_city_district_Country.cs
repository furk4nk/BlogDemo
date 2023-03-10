using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_remove_Table_city_district_Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cities_countries_CountryID",
                table: "cities");

            migrationBuilder.DropForeignKey(
                name: "FK_districts_cities_CityID",
                table: "districts");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_cities_CityID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_countries_CountryID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_districts_districtsDisctrictID",
                table: "writers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_districts",
                table: "districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_countries",
                table: "countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cities",
                table: "cities");

            migrationBuilder.RenameTable(
                name: "districts",
                newName: "District");

            migrationBuilder.RenameTable(
                name: "countries",
                newName: "Country");

            migrationBuilder.RenameTable(
                name: "cities",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "districtsDisctrictID",
                table: "writers",
                newName: "districtsDistrictID");

            migrationBuilder.RenameIndex(
                name: "IX_writers_districtsDisctrictID",
                table: "writers",
                newName: "IX_writers_districtsDistrictID");

            migrationBuilder.RenameColumn(
                name: "DisctrictID",
                table: "District",
                newName: "DistrictID");

            migrationBuilder.RenameIndex(
                name: "IX_districts_CityID",
                table: "District",
                newName: "IX_District_CityID");

            migrationBuilder.RenameIndex(
                name: "IX_cities_CountryID",
                table: "City",
                newName: "IX_City_CountryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_District",
                table: "District",
                column: "DistrictID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_District_City_CityID",
                table: "District",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_City_CityID",
                table: "writers",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_Country_CountryID",
                table: "writers",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_District_districtsDistrictID",
                table: "writers",
                column: "districtsDistrictID",
                principalTable: "District",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Country_CountryID",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_District_City_CityID",
                table: "District");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_City_CityID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_Country_CountryID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_District_districtsDistrictID",
                table: "writers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_District",
                table: "District");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.RenameTable(
                name: "District",
                newName: "districts");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "countries");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "cities");

            migrationBuilder.RenameColumn(
                name: "districtsDistrictID",
                table: "writers",
                newName: "districtsDisctrictID");

            migrationBuilder.RenameIndex(
                name: "IX_writers_districtsDistrictID",
                table: "writers",
                newName: "IX_writers_districtsDisctrictID");

            migrationBuilder.RenameColumn(
                name: "DistrictID",
                table: "districts",
                newName: "DisctrictID");

            migrationBuilder.RenameIndex(
                name: "IX_District_CityID",
                table: "districts",
                newName: "IX_districts_CityID");

            migrationBuilder.RenameIndex(
                name: "IX_City_CountryID",
                table: "cities",
                newName: "IX_cities_CountryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_districts",
                table: "districts",
                column: "DisctrictID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_countries",
                table: "countries",
                column: "CountryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cities",
                table: "cities",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_cities_countries_CountryID",
                table: "cities",
                column: "CountryID",
                principalTable: "countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_districts_cities_CityID",
                table: "districts",
                column: "CityID",
                principalTable: "cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_cities_CityID",
                table: "writers",
                column: "CityID",
                principalTable: "cities",
                principalColumn: "CityID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_countries_CountryID",
                table: "writers",
                column: "CountryID",
                principalTable: "countries",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_districts_districtsDisctrictID",
                table: "writers",
                column: "districtsDisctrictID",
                principalTable: "districts",
                principalColumn: "DisctrictID",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
