using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models.DTOs
{
    public class MapStatsDTO(Map map)
    {
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }

        public int TotalRoundsPlayed { get; set; }
        public int CtRoundsPlayed { get; set; }
        public int TRoundsPlayed { get; set; }
        public int CtPistolRoundsPlayed { get; set; }
        public int TPistolRoundsPlayed { get; set; }
        public int CtPistolRoundsWins { get; set; }
        public int CtPistolRoundsLost { get; set; }
        public int TPistolRoundsWins { get; set; }
        public int TPistolRoundsLost { get; set; }

        // Navigation properties
        public Map Map { get; set; } = map;
    }
}