using System.ComponentModel.DataAnnotations;

namespace CoachingAPI.Models
{
    public class Player
    {
        [Key]
        public Guid PlayerId { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsCoach { get; set; }

        // Navigation properties
        public PlayerStats Stats { get; set; }
        public List<PlayerMapStats> MapStats { get; set; } = new();
        public List<Membership> Memberships { get; set; } = new();
    }
}
