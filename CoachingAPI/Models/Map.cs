using System.ComponentModel.DataAnnotations;

namespace CoachingAPI.Models
{
    public enum MapName
    {
        de_mirage,
        de_vertigo,
        de_ancient,
        de_dust2,
        de_train,
        de_overpass,
        de_nuke,
        de_inferno,
        de_anubis,
        de_tuscan
    }

    public class Map
    {
        [Key]
        public MapName Name { get; set; }
        public bool Active { get; set; }

        static public string GetDisplayName(MapName name)
        {
            string displayName = name switch
            {
                MapName.de_mirage => "Mirage",
                MapName.de_vertigo => "Vertigo",
                MapName.de_ancient => "Ancient",
                MapName.de_dust2 => "Dust II",
                MapName.de_train => "Train",
                MapName.de_overpass => "Overpass",
                MapName.de_nuke => "Nuke",
                MapName.de_inferno => "Inferno",
                MapName.de_anubis => "Anubis",
                MapName.de_tuscan => "Tuscan",
                _ => throw new ArgumentException("Invalid map name"),
            };

            return displayName;
        }
    }
}