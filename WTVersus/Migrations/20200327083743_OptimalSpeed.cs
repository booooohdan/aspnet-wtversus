using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class OptimalSpeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "GSuit",
                table: "Planes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OptimalAilerons",
                table: "Planes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptimalAlitude",
                table: "Planes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OptimalElevator",
                table: "Planes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GSuit",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "OptimalAilerons",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "OptimalAlitude",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "OptimalElevator",
                table: "Planes");
        }
    }
}
