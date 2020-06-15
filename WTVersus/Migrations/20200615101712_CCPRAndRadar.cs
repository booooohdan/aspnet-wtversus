using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class CCPRAndRadar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShellATGMHE",
                table: "Tanks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShellATGMHEVT",
                table: "Tanks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShellATGMTandem",
                table: "Tanks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShellVOG",
                table: "Tanks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TankSearchRadar",
                table: "Tanks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CCRP",
                table: "Planes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShellATGMHE",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "ShellATGMHEVT",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "ShellATGMTandem",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "ShellVOG",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "TankSearchRadar",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "CCRP",
                table: "Planes");
        }
    }
}
