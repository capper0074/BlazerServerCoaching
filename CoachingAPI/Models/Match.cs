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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MatchPlatform MatchPlatform { get; set; }

        // Navigation properties
        public MapName MapName { get; set; }
        public int WinnerTeamId { get; set; }

        [ForeignKey(nameof(MapName))]
        public Map Map { get; set; }
        [ForeignKey(nameof(WinnerTeamId))]
        public Team? Winner { get; set; }

        public List<Team> Teams { get; set; } = [];
        public List<PlayerMatchStats>? PlayerMatchStats { get; set; }
        public TeamMatchStats? TeamMatchStats { get; set; }
    }
}