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
        public Guid FKPlayerId { get; set; }
        public Guid FKTeamId { get; set; }
        public Guid FKMatchId { get; set; }

        [ForeignKey(nameof(FKPlayerId))]
        public Player Player { get; set; }
        [ForeignKey(nameof(FKMatchId))]
        public Match Match { get; set; }

        public TeamMatchStats TeamMatchStats { get; set; }
    }
}
