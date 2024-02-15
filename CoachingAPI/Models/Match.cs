using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Match
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public MatchPlatform MatchPlatform { get; set; }

        // Navigation properties
        public List<Team> Teams { get; set; } = new List<Team>();
        public Team? Winner { get; set; }
    }
}