using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class PlayerMatchStats
    {
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public double KDRatio { get; set; }
        public double KRRatio { get; set; }
        public int Headshots { get; set; }

        // Navigation properties
        public int PlayerId { get; set; }
        public int TeamId { get; set; }
        public int MatchId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
        [ForeignKey(nameof(MatchId))]
        public Match Match { get; set; }

        public TeamMatchStats TeamMatchStats { get; set; }
    }
}
