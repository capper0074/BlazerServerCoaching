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
        public Guid FKPlayerId { get; set; }
        public Guid FKTeamId { get; set; }

        [ForeignKey(nameof(FKPlayerId))]
        public Player Player { get; set; }
        [ForeignKey(nameof(FKTeamId))]
        public Team Team { get; set; }
    }
}
