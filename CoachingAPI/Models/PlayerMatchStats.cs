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
        public Guid FK_PlayerId { get; set; }
        public Guid FK_MatchId { get; set; }
        public Guid FK_TeamMatchStats_TeamId { get; set; }

        [ForeignKey(nameof(FK_PlayerId))]
        public Player RelatedPlayer { get; set; }
        [ForeignKey(nameof(FK_MatchId))]
        public Match RelatedMatch { get; set; }

        public TeamMatchStats TeamMatchStats { get; set;}
    }
}
