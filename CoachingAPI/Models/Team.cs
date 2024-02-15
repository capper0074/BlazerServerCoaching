using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Team
    {
        [Key]
        public string Name { get; set; } = string.Empty;
        public bool IsMatchMaking { get; set; }
        public List<Player> Players { get; set; } = new();
        public List<Player> Standins { get; set; } = new();
        public Player? Coach { get; set; }

        // Navigation properties ----------------------------------
        public Guid PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
    }
}