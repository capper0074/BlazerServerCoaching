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
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public MatchPlatform MatchPlatform { get; set; }

        // Navigation properties
        public MapName FKMapName { get; set; }
        public Guid FKTeamWinnerId { get; set; }

        [ForeignKey(nameof(FKMapName))]
        public Map Map { get; set; }
        [ForeignKey(nameof(FKTeamWinnerId))]
        public Team? Winner { get; set; }

        public List<Team> Teams { get; set; } = [];
        public List<PlayerMatchStats>? PlayerMatchStats { get; set; }
        public TeamMatchStats? TeamMatchStats { get; set; }
    }
}