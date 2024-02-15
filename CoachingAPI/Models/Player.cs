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

        public List<Match> Matches { get; set; } = new();
        public PlayerStats Stats { get; set; } = new();
        public List<PlayerMapStats> MapStats { get; set; } = new();
        public List<Team> FormerTeams { get; set; } = new();
        public Team CurrentTeam { get; set; } = new();

        // Navigation properties ----------------------------------
        //public string FormerTeamName { get; set; }

    }
}
