using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class AddWikiLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Planes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WikiDescription",
                table: "Planes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WikiLink",
                table: "Planes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "WikiDescription",
                table: "Planes");

            migrationBuilder.DropColumn(
                name: "WikiLink",
                table: "Planes");
        }
    }
}
