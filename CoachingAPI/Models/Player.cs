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
        public List<Membership> Memberships { get; set; } = new();
    }
}
