using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class TeamMatchStats
    {
        //public int Kills { get; set; }
        //public int Deaths { get; set; }
        //public int Assists { get; set; }
        //public double KDRatio { get; set; }
        //public double KRRatio { get; set; }
        //public int Headshots { get; set; }

        public int TRoundsPlayed { get; set; }
        public int TRoundsWins { get; set; }
        public int TPistolRoundWon { get; set; }
        public int CTRoundsPlayed { get; set; }
        public int CTRoundsWon { get; set; }
        public int CTPistolRoundWon { get; set; }

        // Navigation properties
        public Guid FK_TeamId { get; set; }
        public Guid FK_MatchId { get; set; }

        [ForeignKey(nameof(FK_TeamId))]
        public Team RelatedTeam { get; set; }
        [ForeignKey(nameof(FK_MatchId))]
        public Match RelatedMatch { get; set; }
    }
}
