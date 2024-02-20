using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Team
    {
        [Key]
        public string Name { get; set; }
        public bool IsMatchMaking { get; set; }

        public List<Membership> Memberships { get; set; } = new();
        public List<Match> Matches { get; set; } = new();
        public List<Match> WonMatches { get; set; } = new();

        // Navigation properties
        //public List<Player> Players { get; set; } = new();
        //public List<Player> Standins { get; set; } = new();
        //public Player? Coach { get; set; }
    }
}