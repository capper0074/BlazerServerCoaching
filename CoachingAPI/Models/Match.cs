using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoachingAPI.Models
{
    public enum MatchPlatform
    {
        Scrim,
        FaceIt,
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
        [JsonIgnore]
        public MapName MapName { get; set; }
        public int WinnerTeamId { get; set; }

        [ForeignKey(nameof(MapName))]
        public Map Map { get; set; }
        [JsonIgnore] // Don't show the winner team object in the JSON response, only the ID
        [ForeignKey(nameof(WinnerTeamId))]
        public Team? Winner { get; set; }

        public List<Team> Teams { get; set; } = [];
        //public List<PlayerMatchStats>? PlayerMatchStats { get; set; }
        //public List<TeamMatchStats>? TeamMatchStats { get; set; }
    }
}