using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class FullNameDeleteThrustAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Planes");

            migrationBuilder.AddColumn<int>(
                name: "ThrustToWeight",
                table: "Planes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThrustToWeight",
                table: "Planes");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Planes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
