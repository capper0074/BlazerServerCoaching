using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Team
    {
        [Key]
        public string Name { get; set; }
        public bool IsMatchMaking { get; set; }

        // Navigation properties
        public List<Player> Players { get; set; } = new();
        public List<Player> Standins { get; set; } = new();
        public Player? Coach { get; set; }
    }
}