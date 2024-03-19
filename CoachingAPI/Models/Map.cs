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
    }
}