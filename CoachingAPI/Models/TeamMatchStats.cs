using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class TeamMatchStats
    {
        public int TRoundsPlayed { get; set; }
        public int TRoundsWins { get; set; }
        public int TPistolRoundWon { get; set; }
        public int CTRoundsPlayed { get; set; }
        public int CTRoundsWon { get; set; }
        public int CTPistolRoundWon { get; set; }

        // Navigation properties
        public Guid FKTeamId { get; set; }
        public Guid FKMatchId { get; set; }

        [ForeignKey(nameof(FKTeamId))]
        public Team Team { get; set; }
        [ForeignKey(nameof(FKMatchId))]
        public Match Match { get; set; }
    }
}
