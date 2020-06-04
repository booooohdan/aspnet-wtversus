using Microsoft.EntityFrameworkCore.Migrations;

namespace WTVersus.Migrations
{
    public partial class ShipAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ships",
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
                    FirstLaunchYear = table.Column<int>(nullable: true),
                    RepairCost = table.Column<int>(nullable: true),
                    ViewCount = table.Column<int>(nullable: true),
                    WikiLink = table.Column<string>(nullable: true),
                    WikiDescription = table.Column<string>(nullable: true),
                    MaxSpeed = table.Column<int>(nullable: true),
                    ReverseSpeed = table.Column<int>(nullable: true),
                    Acceleration = table.Column<int>(nullable: true),
                    BrakingTime = table.Column<int>(nullable: true),
                    Turn360 = table.Column<int>(nullable: true),
                    Displacement = table.Column<int>(nullable: true),
                    CrewCount = table.Column<int>(nullable: true),
                    ArmorTower = table.Column<int>(nullable: true),
                    ArmorHull = table.Column<int>(nullable: true),
                    MainCaliberSize = table.Column<int>(nullable: true),
                    MainCaliberReload = table.Column<double>(nullable: true),
                    MainCaliberName = table.Column<string>(nullable: true),
                    AUCaliberName = table.Column<string>(nullable: true),
                    AACaliberName = table.Column<string>(nullable: true),
                    TorpedoItem = table.Column<int>(nullable: true),
                    TorpedoMaxSpeed = table.Column<int>(nullable: true),
                    TorpedoTNT = table.Column<int>(nullable: true),
                    IsHaveDepthCharge = table.Column<bool>(nullable: false),
                    IsHaveTorpedo = table.Column<bool>(nullable: false),
                    IsHaveRocket = table.Column<bool>(nullable: false),
                    IsHaveMine = table.Column<bool>(nullable: false),
                    IsHaveAirRadar = table.Column<bool>(nullable: false),
                    IsHaveShipRadar = table.Column<bool>(nullable: false),
                    MC_SAP = table.Column<bool>(nullable: false),
                    MC_AP = table.Column<bool>(nullable: false),
                    MC_APHE = table.Column<bool>(nullable: false),
                    MC_APCR = table.Column<bool>(nullable: false),
                    MC_HE = table.Column<bool>(nullable: false),
                    MC_HEVT = table.Column<bool>(nullable: false),
                    MC_HEDF = table.Column<bool>(nullable: false),
                    MC_FOG = table.Column<bool>(nullable: false),
                    MC_Shrapnel = table.Column<bool>(nullable: false),
                    AU_SAP = table.Column<bool>(nullable: false),
                    AU_AP = table.Column<bool>(nullable: false),
                    AU_APHE = table.Column<bool>(nullable: false),
                    AU_APCR = table.Column<bool>(nullable: false),
                    AU_HE = table.Column<bool>(nullable: false),
                    AU_HEVT = table.Column<bool>(nullable: false),
                    AU_HEDF = table.Column<bool>(nullable: false),
                    AU_FOG = table.Column<bool>(nullable: false),
                    AU_Shrapnel = table.Column<bool>(nullable: false),
                    AAA_SAP = table.Column<bool>(nullable: false),
                    AAA_AP = table.Column<bool>(nullable: false),
                    AAA_APHE = table.Column<bool>(nullable: false),
                    AAA_APCR = table.Column<bool>(nullable: false),
                    AAA_HE = table.Column<bool>(nullable: false),
                    AAA_HEVT = table.Column<bool>(nullable: false),
                    AAA_HEDF = table.Column<bool>(nullable: false),
                    AAA_FOG = table.Column<bool>(nullable: false),
                    AAA_Shrapnel = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ships");
        }
    }
}
