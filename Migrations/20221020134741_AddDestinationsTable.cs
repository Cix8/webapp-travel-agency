using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapp_travel_agency.Migrations
{
    public partial class AddDestinationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DurationInDays",
                table: "TravelPackages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DestinationTravelPackage",
                columns: table => new
                {
                    DestinationsId = table.Column<int>(type: "int", nullable: false),
                    TravelPackagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationTravelPackage", x => new { x.DestinationsId, x.TravelPackagesId });
                    table.ForeignKey(
                        name: "FK_DestinationTravelPackage_Destinations_DestinationsId",
                        column: x => x.DestinationsId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DestinationTravelPackage_TravelPackages_TravelPackagesId",
                        column: x => x.TravelPackagesId,
                        principalTable: "TravelPackages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DestinationTravelPackage_TravelPackagesId",
                table: "DestinationTravelPackage",
                column: "TravelPackagesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DestinationTravelPackage");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropColumn(
                name: "DurationInDays",
                table: "TravelPackages");
        }
    }
}
