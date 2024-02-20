using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Membership
    {
        public DateTime JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public MembershipType MembershipType { get; set; }

        // Navigation properties
        public Guid PlayerId { get; set; }
        public string TeamName { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }
        [ForeignKey(nameof(TeamName))]
        public Team Team { get; set; }
    }
}
