using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_removeTAble_city_district_Country : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_writers_City_CityID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_Country_CountryID",
                table: "writers");

            migrationBuilder.DropForeignKey(
                name: "FK_writers_District_districtsDistrictID",
                table: "writers");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_writers_CityID",
                table: "writers");

            migrationBuilder.DropIndex(
                name: "IX_writers_CountryID",
                table: "writers");

            migrationBuilder.DropIndex(
                name: "IX_writers_districtsDistrictID",
                table: "writers");

            migrationBuilder.DropColumn(
                name: "CityID",
                table: "writers");

            migrationBuilder.DropColumn(
                name: "CountryID",
                table: "writers");

            migrationBuilder.DropColumn(
                name: "districtsDistrictID",
                table: "writers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityID",
                table: "writers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountryID",
                table: "writers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisctrictID",
                table: "writers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "districtsDistrictID",
                table: "writers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityID);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "District",
                columns: table => new
                {
                    DistrictID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityID = table.Column<int>(type: "int", nullable: false),
                    DisctrictName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_District", x => x.DistrictID);
                    table.ForeignKey(
                        name: "FK_District_City_CityID",
                        column: x => x.CityID,
                        principalTable: "City",
                        principalColumn: "CityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_writers_CityID",
                table: "writers",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_writers_CountryID",
                table: "writers",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_writers_districtsDistrictID",
                table: "writers",
                column: "districtsDistrictID");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryID",
                table: "City",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_District_CityID",
                table: "District",
                column: "CityID");

            migrationBuilder.AddForeignKey(
                name: "FK_writers_City_CityID",
                table: "writers",
                column: "CityID",
                principalTable: "City",
                principalColumn: "CityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_Country_CountryID",
                table: "writers",
                column: "CountryID",
                principalTable: "Country",
                principalColumn: "CountryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_writers_District_districtsDistrictID",
                table: "writers",
                column: "districtsDistrictID",
                principalTable: "District",
                principalColumn: "DistrictID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
