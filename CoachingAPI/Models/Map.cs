using System.ComponentModel.DataAnnotations;

namespace CoachingAPI.Models
{
    public class Map
    {
        [Key]
        public MapName Name { get; set; }
        public bool Active { get; set; }
    }
}