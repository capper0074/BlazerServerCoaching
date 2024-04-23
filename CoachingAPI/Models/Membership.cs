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
        public MembershipType MembershipType { get; set; }

        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        // Navigation properties
        public int PlayerId { get; set; }
        public int TeamId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; }
    }
}
