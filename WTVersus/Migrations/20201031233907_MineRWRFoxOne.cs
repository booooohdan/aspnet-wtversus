using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class MineRWRFoxOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RWR",
                table: "Tanks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AAFoxOneMissile",
                table: "Planes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HMine",
                table: "Planes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RWR",
                table: "Tanks");

            migrationBuilder.DropColumn(
                name: "AAFoxOneMissile",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "HMine",
                table: "Planes");
        }
    }
}
