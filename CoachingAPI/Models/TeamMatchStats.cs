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
        public int TeamId { get; set; }
        public int MatchId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
        [ForeignKey(nameof(MatchId))]
        public Match Match { get; set; }
    }
}
