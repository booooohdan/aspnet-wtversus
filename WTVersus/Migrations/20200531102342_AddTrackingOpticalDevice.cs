using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class AddTrackingOpticalDevice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThrustToWeight",
                table: "Planes");

            migrationBuilder.AddColumn<bool>(
                name: "OpticalTracking",
                table: "Helis",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpticalTracking",
                table: "Helis");

            migrationBuilder.AddColumn<double>(
                name: "ThrustToWeight",
                table: "Planes",
                type: "float",
                nullable: true);
        }
    }
}
