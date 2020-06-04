namespace WTVersus.Models
{
    public class Ship
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
        public int? FirstLaunchYear { get; set; }
        public int? RepairCost { get; set; }
        public int? ViewCount { get; set; } //not implement
        public string WikiLink { get; set; }
        public string WikiDescription { get; set; } //not implement

        public int? MaxSpeed { get; set; }  
        public int? ReverseSpeed { get; set; } 
        public int? Acceleration { get; set; } 
        public int? BrakingTime { get; set; } 
        public int? Turn360 { get; set; } 

        public int? Displacement { get; set; } 
        public int? CrewCount { get; set; }  
        public int? ArmorTower { get; set; } 
        public int? ArmorHull { get; set; } 

        public int? MainCaliberSize { get; set; } 
        public double? MainCaliberReload { get; set; } 
        public string MainCaliberName { get; set; } 
        public string AUCaliberName { get; set; } 
        public string AACaliberName { get; set; } 
        public int? TorpedoItem { get; set; } 
        public int? TorpedoMaxSpeed { get; set; } 
        public int? TorpedoTNT { get; set; } 

        public bool IsHaveDepthCharge { get; set; }
        public bool IsHaveTorpedo { get; set; }
        public bool IsHaveRocket { get; set; }
        public bool IsHaveMine { get; set; }
        public bool IsHaveAirRadar { get; set; }
        public bool IsHaveShipRadar { get; set; }

        public bool MC_SAP { get; set; } 
        public bool MC_AP { get; set; } 
        public bool MC_APHE { get; set; } 
        public bool MC_APCR { get; set; } 
        public bool MC_HE { get; set; } 
        public bool MC_HEVT { get; set; }  
        public bool MC_HEDF { get; set; } 
        public bool MC_FOG { get; set; } 
        public bool MC_Shrapnel { get; set; } 

        public bool AU_SAP { get; set; }
        public bool AU_AP { get; set; }
        public bool AU_APHE { get; set; }
        public bool AU_APCR { get; set; }
        public bool AU_HE { get; set; }
        public bool AU_HEVT { get; set; }
        public bool AU_HEDF { get; set; }
        public bool AU_FOG { get; set; }
        public bool AU_Shrapnel { get; set; }

        public bool AAA_SAP { get; set; }
        public bool AAA_AP { get; set; }
        public bool AAA_APHE { get; set; }
        public bool AAA_APCR { get; set; }
        public bool AAA_HE { get; set; }
        public bool AAA_HEVT { get; set; }
        public bool AAA_HEDF { get; set; }
        public bool AAA_FOG { get; set; }
        public bool AAA_Shrapnel { get; set; }
    }
}
