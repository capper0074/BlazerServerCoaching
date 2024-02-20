using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public enum MatchPlatform
    {
        FaceIt,
        Scrim,
        Metal,
        YouSee,
        Power
    }

    public class Match
    {
        [Key]
        public Guid MatchId { get; set; }
        public DateTime Date { get; set; }
        public MatchPlatform MatchPlatform { get; set; }

        // Navigation properties
        public string? WinnerTeamName { get; set; }

        public List<Team> Teams { get; set; } = new();
        [ForeignKey(nameof(WinnerTeamName))]
        public Team? Winner { get; set; }
    }
}