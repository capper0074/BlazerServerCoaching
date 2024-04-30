using CoachingAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoachingAPI.Models
{
    public class Team : ITrackable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsMatchMaking { get; set; }

        // Navigation properties
        public List<Membership> Memberships { get; set; } = [];
        [JsonIgnore] // Ignore this to avoid circular reference when serializing to JSON
        public List<Match> Matches { get; set; } = [];
    }
}