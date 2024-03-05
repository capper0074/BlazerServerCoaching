using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsMatchMaking { get; set; }

        // Navigation properties
        public Guid? FK_GeneralStatsId { get; set; }

        public List<Membership> Memberships { get; set; } = new();
        public List<Match> Matches { get; set; } = new();
        [ForeignKey(nameof(FK_GeneralStatsId))]
        public GeneralStats Stats { get; set; }
        // public List<Match> WonMatches { get; set; } = new();
    }
}