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
        public MapName FK_MapName { get; set; }
        [ForeignKey(nameof(FK_MapName))]
        public Map Map { get; set; }

        // Navigation properties
        public Guid FK_WinnerTeamId { get; set; }

        public List<Team> Teams { get; set; } = new();
        [ForeignKey(nameof(FK_WinnerTeamId))]
        public Team Winner { get; set; }
        public List<PlayerMatchStats>? PlayerMatchStats { get; set; }
        public TeamMatchStats? TeamMatchStats { get; set; }
    }
}