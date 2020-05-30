using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class HeliAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Helis",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    BR = table.Column<double>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    FirstFlyYear = table.Column<int>(nullable: true),
                    RepairCost = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    WikiLink = table.Column<string>(nullable: true),
                    WikiDescription = table.Column<string>(nullable: true),
                    MaxSpeed = table.Column<int>(nullable: true),
                    ClimbTo1000 = table.Column<int>(nullable: true),
                    Turn360 = table.Column<int>(nullable: true),
                    EnginePower = table.Column<int>(nullable: true),
                    Weight = table.Column<int>(nullable: true),
                    AGMCount = table.Column<int>(nullable: true),
                    AGMArmorPenetration = table.Column<int>(nullable: true),
                    AGMSpeed = table.Column<int>(nullable: true),
                    AGMRange = table.Column<int>(nullable: true),
                    AAMCount = table.Column<int>(nullable: true),
                    ASMCount = table.Column<int>(nullable: true),
                    BombLoad = table.Column<int>(nullable: true),
                    OffensiveWeapon = table.Column<string>(nullable: true),
                    AGMissile = table.Column<bool>(nullable: false),
                    AutoAGMissile = table.Column<bool>(nullable: false),
                    AAMissile = table.Column<bool>(nullable: false),
                    ASMissile = table.Column<bool>(nullable: false),
                    Bomb = table.Column<bool>(nullable: false),
                    TurningCannon = table.Column<bool>(nullable: false),
                    FixedCannon = table.Column<bool>(nullable: false),
                    IRCM = table.Column<bool>(nullable: false),
                    HIRSS = table.Column<bool>(nullable: false),
                    Flares = table.Column<bool>(nullable: false),
                    RWR = table.Column<bool>(nullable: false),
                    LaserDesignator = table.Column<bool>(nullable: false),
                    CCIP = table.Column<bool>(nullable: false),
                    ThermalGunner = table.Column<bool>(nullable: false),
                    AirRadar = table.Column<bool>(nullable: false),
                    GroundRadar = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Helis", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Helis");
        }
    }
}
