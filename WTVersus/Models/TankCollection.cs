using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WTVersus.Models
{
    public class Tank
    {
        public int Id { get; set; }
        public int? VehicleId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public string Rank { get; set; }
        public double? BR { get; set; }
        public string Type { get; set; }
        public string Class { get; set; }
        public int? FirstRideYear { get; set; }
        public int? RepairCost { get; set; }
        public int? ViewCount { get; set; } //not implement
        public string WikiLink { get; set; }
        public string WikiDescription { get; set; } //not implement

        public int? MaxSpeedAtRoad { get; set; }
        public int? MaxSpeedAtTerrain { get; set; }
        public int? MaxReverseSpeed { get; set; }
        public int? AccelerationTo100 { get; set; }
        public int? TurnTurretTime { get; set; }
        public int? TurnHullTime { get; set; }
        public int? EnginePower { get; set; }
        public double? Weight { get; set; }
        public string Cannon { get; set; }
        public int? Penetration { get; set; }
        public int? ShellSpeed { get; set; }
        public double? ReloadTime { get; set; }
        public int? UpAimAngle { get; set; }
        public int? DownAimAngle { get; set; }
        public int? ReducedArmorFrontTurret { get; set; }
        public int? ReducedArmorTopSheet { get; set; }
        public int? ReducedArmorBottomSheet { get; set; }

        public bool ShellAP { get; set; }
        public bool ShellAPHE { get; set; }
        public bool ShellHE { get; set; }
        public bool ShellAPCR { get; set; }
        public bool ShellAPDS { get; set; }
        public bool ShellAPFSDS { get; set; }
        public bool ShellHEAT { get; set; }
        public bool ShellHEATFS { get; set; }
        public bool ShellShrapnel { get; set; }
        public bool ShellHESH { get; set; }
        public bool ShellATGM { get; set; }
        public bool ShellSSM { get; set; }
        public bool ShellHEATGRENADE { get; set; }
        public bool ShellHEVT { get; set; }
        public bool ShellSAM { get; set; }
        public bool ShellSmoke { get; set; }

        public bool AddOnArmor { get; set; }
        public bool ReactiveArmor { get; set; }
        public bool Hydropneumatic { get; set; }
        public bool IRSpotlight { get; set; }
        public bool AirSearchRadar { get; set; }
        public bool AirLockRadar { get; set; }
        public bool GrenadeSmoke { get; set; }
        public bool ExhaustSmoke { get; set; }
        public bool Amphibious { get; set; }
        public bool AutoLoader { get; set; }
        public bool AAMachineGun { get; set; }
        public bool Stabilizer { get; set; }
        public bool HullBreak { get; set; }
        public bool NVDGunner { get; set; }
        public bool ThermalGunner { get; set; }
        public bool NVDCommander { get; set; }
        public bool ThermalCommander { get; set; }


    }

    public class TankCollection
    {
        public AppDbContext Context { get; }
        public TankCollection(AppDbContext context)
        {
            Context = context;
        }
    }
}
