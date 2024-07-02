namespace MyGame.Core
{

    using System.Collections.Generic;



    [System.Serializable]
    #nullable enable
    public class Item
    {
        // General item attributes
        public string Name { get; set; } = string.Empty;    
        public string? Nickname { get; set; }
        public string? Description { get; set; }
        public int? Rating { get; set; } // Nullable
        public Dictionary<string, double>? RatingMultipliers { get; set; } // Nullable

        // Physical attributes
        public float? Weight { get; set; } // Nullable
        public float? RetailPrice { get; set; } // Nullable

        // Equipment type and slot
        public string? Type { get; set; }
        public string? Slot { get; set; }

        // Combat-related attributes
        public int? Accuracy { get; set; } // Nullable
        public int? BaseDamage { get; set; } // Nullable
        public bool? AddStrToDmg { get; set; } // Nullable
        public bool? AddRtgToDmg { get; set; } // Nullable
        public string? DamageType { get; set; }
        public float? ArmorPiercing { get; set; } // Nullable
        public List<string>? FiringModes { get; set; } // Nullable
        public string? SpecialDamage { get; set; }
        public int? ArmorRating { get; set; } // Nullable
        public int? ModCapacity { get; set; } // Nullable
        public List<string>? Mods { get; set; } // Nullable
        public string? Caliber { get; set; }
        public int? MagazineSize { get; set; } // Nullable
        public string? MagazineType { get; set; }
        public int? Availability { get; set; } // Nullable
        public string? Legality { get; set; }
        public int? Reach { get; set; } // Nullable

        // Matrix attributes
        public List<int>? MatrixArray { get; set; } // Nullable
        public int? MatrixAttack { get; set; } // Nullable
        public int? Sleaze { get; set; } // Nullable
        public int? DataProcessing { get; set; } // Nullable
        public int? Firewall { get; set; } // Nullable
        public int? MaxPrograms { get; set; } // Nullable
        public List<string>? Programs { get; set; } // Nullable

        // Skill-related attributes
        public string? RelevantSkill { get; set; }
        public int? RecoilComp { get; set; } // Nullable
        public string? Range { get; set; }
        public int? MinimumStrength { get; set; } // Nullable
    }

    #nullable restore
}