using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class CreateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    BR = table.Column<double>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    FirstFlyYear = table.Column<string>(nullable: true),
                    RepairCost = table.Column<int>(nullable: false),
                    MaxSpeedAt0 = table.Column<int>(nullable: false),
                    MaxSpeedAt5000 = table.Column<int>(nullable: false),
                    Climb = table.Column<int>(nullable: false),
                    BombLoad = table.Column<int>(nullable: false),
                    TurnAt0 = table.Column<double>(nullable: false),
                    EnginePower = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Flutter = table.Column<int>(nullable: false),
                    BurstMass = table.Column<double>(nullable: false),
                    CourseWeapon = table.Column<string>(nullable: true),
                    ASMissile = table.Column<bool>(nullable: false),
                    AAMissile = table.Column<bool>(nullable: false),
                    AGMissile = table.Column<bool>(nullable: false),
                    HCannon = table.Column<bool>(nullable: false),
                    HBomb = table.Column<bool>(nullable: false),
                    HTorpedo = table.Column<bool>(nullable: false),
                    AirRadar = table.Column<bool>(nullable: false),
                    GroundRadar = table.Column<bool>(nullable: false),
                    WrongMusic = table.Column<bool>(nullable: false),
                    Turrel = table.Column<bool>(nullable: false),
                    Flares = table.Column<bool>(nullable: false),
                    CCIP = table.Column<bool>(nullable: false),
                    RWR = table.Column<bool>(nullable: false),
                    AirBrake = table.Column<bool>(nullable: false),
                    Parachute = table.Column<bool>(nullable: false),
                    Tailhook = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planes");
        }
    }
}
