using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoachingAPI.Models
{
    public enum MembershipType
    {
        ActiveRoster,
        StandIn,
        Coach
    }

    public class Membership
    {
        public MembershipType MembershipType { get; set; }

        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        // Navigation properties
        public int PlayerId { get; set; }
        public int TeamId { get; set; }

        [JsonIgnore] // Use this to prevent circular reference when serializing to JSON
        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
        [JsonIgnore] // Use this to prevent circular reference when serializing to JSON
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
    }
}
