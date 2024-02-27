using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class Player
    {
        [Key]
        public Guid PlayerId { get; set; }

        public string Name { get; set; } = string.Empty;
        public bool IsCoach { get; set; }

        // Navigation properties
        public Guid? FK_GeneralStatsId { get; set; }

        [ForeignKey(nameof(FK_GeneralStatsId))]
        public GeneralStats Stats { get; set; }
        public List<Membership> Memberships { get; set; } = new();
    }
}
