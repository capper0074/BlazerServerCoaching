using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }

        public MatchPlatform MatchPlatform { get; set; }

        public List<Team> Teams { get; set; } = new List<Team>();
        public Team Winner { get; set; }
        public DateTime Date { get; set; }

        // Navigation properties ----------------------------------
        public Guid PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
    }
}