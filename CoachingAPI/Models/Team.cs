using System.ComponentModel.DataAnnotations;

namespace CoachingAPI.Models
{
    public class Team
    {
        [Key]
        public string Name { get; set; }
        public bool IsMatchMaking { get; set; }

        // Navigation properties
        public List<Membership> Memberships { get; set; } = new();
        public List<Match> Matches { get; set; } = new();
        // public List<Match> WonMatches { get; set; } = new();
    }
}