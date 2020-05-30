namespace WTVersus.Models
{
    public class Heli
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
        public int? FirstFlyYear { get; set; }
        public int? RepairCost { get; set; }
        public int? ViewCount { get; set; } //not implement
        public string WikiLink { get; set; }
        public string WikiDescription { get; set; } //not implement

        public int? MaxSpeed { get; set; }
        public int? ClimbTo1000 { get; set; }
        public int? Turn360 { get; set; }
        public int? EnginePower { get; set; }
        public int? Weight { get; set; }

        public int? AGMCount { get; set; }
        public int? AGMArmorPenetration { get; set; }
        public int? AGMSpeed { get; set; }
        public int? AGMRange { get; set; }
        public int? AAMCount { get; set; }
        public int? ASMCount { get; set; }
        public int? BombLoad { get; set; }
        public string OffensiveWeapon { get; set; }

        public bool AGMissile { get; set; }
        public bool AutoAGMissile { get; set; }
        public bool AAMissile { get; set; }
        public bool ASMissile { get; set; } //НАР
        public bool Bomb { get; set; }
        public bool TurningCannon { get; set; }
        public bool FixedCannon { get; set; }

        public bool IRCM { get; set; } //СОЕП
        public bool HIRSS { get; set; } //ЭВУ
        public bool Flares { get; set; } //ЛТЦ
        public bool RWR { get; set; } //СПО

        public bool LaserDesignator { get; set; } //СПО
        public bool CCIP { get; set; } //СПО
        public bool ThermalGunner { get; set; } //СПО
        public bool AirRadar { get; set; }
        public bool GroundRadar { get; set; }
    }
}
