using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WTVersus.Models
{
    public class Plane
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
        public string FirstFlyYear { get; set; }
        public int? RepairCost { get; set; } //Не реалізовано 
        //Data Source=SQL5053.site4now.net;Initial Catalog=DB_A564A8_bo7145907;User Id=DB_A564A8_bo7145907_admin;Password=7145907bo;

        public int? MaxSpeedAt0 { get; set; }
        public int? MaxSpeedAt5000 { get; set; }
        public int? Climb { get; set; }
        public int? BombLoad { get; set; }
        public double? TurnAt0 { get; set; }
        public int? EnginePower { get; set; }
        public int? Weight { get; set; }
        public int? ThrustToWeight { get; set; }
        public int? Flutter { get; set; }
        public double? BurstMass { get; set; }
        public string CourseWeapon { get; set; }

        public bool ASMissile { get; set; } //НАР
        public bool AAMissile { get; set; }
        public bool AGMissile { get; set; }
        public bool HCannon { get; set; }
        public bool HBomb { get; set; }
        public bool HTorpedo { get; set; }
        public bool WrongMusic { get; set; }

        public bool Turrel { get; set; }
        public bool RWR { get; set; } //СПО
        public bool Flares { get; set; } //ЛТЦ

        public bool AirBrake { get; set; } //Пов тормоз
        public bool Parachute { get; set; } //Торм парашут
        public bool Tailhook { get; set; } //Гак для авіаносця
        public bool AirRadar { get; set; }
        public bool GroundRadar { get; set; }
        public bool CCIP { get; set; } //Constantly Computed Impact Point (CCIP)


    }



    public class PlaneCollection
    {
        public AppDbContext Context { get; }
        public PlaneCollection(AppDbContext context)
        {
            Context = context;
        }
    }
}
