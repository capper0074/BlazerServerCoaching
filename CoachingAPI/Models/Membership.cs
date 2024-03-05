using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public MembershipType MembershipType { get; set; }

        // Navigation properties
        public Guid PlayerId { get; set; }
        public Guid TeamId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
    }
}
