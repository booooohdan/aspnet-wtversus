using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class InitialTheTanks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tanks",
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
                    FirstRideYear = table.Column<int>(nullable: true),
                    RepairCost = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    WikiLink = table.Column<string>(nullable: true),
                    WikiDescription = table.Column<string>(nullable: true),
                    MaxSpeedAtRoad = table.Column<int>(nullable: true),
                    MaxSpeedAtTerrain = table.Column<int>(nullable: true),
                    MaxReverseSpeed = table.Column<int>(nullable: true),
                    AccelerationTo100 = table.Column<int>(nullable: true),
                    TurnTurretTime = table.Column<int>(nullable: true),
                    TurnHullTime = table.Column<int>(nullable: true),
                    EnginePower = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    Cannon = table.Column<string>(nullable: true),
                    Penetration = table.Column<int>(nullable: true),
                    ShellSpeed = table.Column<int>(nullable: true),
                    ReloadTime = table.Column<double>(nullable: true),
                    UpAimAngle = table.Column<int>(nullable: true),
                    DownAimAngle = table.Column<int>(nullable: true),
                    ReducedArmorFrontTurret = table.Column<int>(nullable: true),
                    ReducedArmorTopSheet = table.Column<int>(nullable: true),
                    ReducedArmorBottomSheet = table.Column<int>(nullable: true),
                    ShellAP = table.Column<bool>(nullable: false),
                    ShellAPHE = table.Column<bool>(nullable: false),
                    ShellHE = table.Column<bool>(nullable: false),
                    ShellAPCR = table.Column<bool>(nullable: false),
                    ShellAPDS = table.Column<bool>(nullable: false),
                    ShellAPFSDS = table.Column<bool>(nullable: false),
                    ShellHEAT = table.Column<bool>(nullable: false),
                    ShellHEATFS = table.Column<bool>(nullable: false),
                    ShellShrapnel = table.Column<bool>(nullable: false),
                    ShellHESH = table.Column<bool>(nullable: false),
                    ShellATGM = table.Column<bool>(nullable: false),
                    ShellSSM = table.Column<bool>(nullable: false),
                    ShellHEATGRENADE = table.Column<bool>(nullable: false),
                    ShellHEVT = table.Column<bool>(nullable: false),
                    ShellSAM = table.Column<bool>(nullable: false),
                    ShellSmoke = table.Column<bool>(nullable: false),
                    AddOnArmor = table.Column<bool>(nullable: false),
                    ReactiveArmor = table.Column<bool>(nullable: false),
                    Hydropneumatic = table.Column<bool>(nullable: false),
                    IRSpotlight = table.Column<bool>(nullable: false),
                    AirSearchRadar = table.Column<bool>(nullable: false),
                    AirLockRadar = table.Column<bool>(nullable: false),
                    GrenadeSmoke = table.Column<bool>(nullable: false),
                    ExhaustSmoke = table.Column<bool>(nullable: false),
                    Amphibious = table.Column<bool>(nullable: false),
                    AutoLoader = table.Column<bool>(nullable: false),
                    AAMachineGun = table.Column<bool>(nullable: false),
                    Stabilizer = table.Column<bool>(nullable: false),
                    HullBreak = table.Column<bool>(nullable: false),
                    NVDGunner = table.Column<bool>(nullable: false),
                    ThermalGunner = table.Column<bool>(nullable: false),
                    NVDCommander = table.Column<bool>(nullable: false),
                    ThermalCommander = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tanks");
        }
    }
}
