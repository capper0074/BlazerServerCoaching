using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsCoach { get; set; }

        #region stats
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int KDRatio { get; set; }
        public int KRRatio { get; set; }
        public int Headshots { get; set; }
        #endregion

        // Navigation properties
        public List<Match> Matches { get; set; } = new();
        public PlayerStats Stats { get; set; }
        public List<PlayerMapStats> MapStats { get; set; } = new();
        public List<Team> FormerTeams { get; set; } = new();
        public Team CurrentTeam { get; set; }
    }
}
