using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class PlayerMapStats
    {
        public Map Map { get; set; }

        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public int TotalRoundsPlayed { get; set; }
        public int CtRoundsPlayed { get; set; }
        public int TRoundsPlayed { get; set; }
        public int CtPistolRoundsPlayed { get; set; }
        public int TPistolRoundsPlayed { get; set; }
        public int CtPistolRoundsWon { get; set; }
        public int CtPistolRoundsLost { get; set; }
        public int TPistolRoundsWins { get; set; }
        public int TPistolRoundsLost { get; set; }

        // Navigation properties ----------------------------------
        public Guid PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
    }
}