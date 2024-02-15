using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class PlayerTeamHistory
    {
        [Key]
        public int Id { get; set; }

        public Guid PlayerId { get; set; }
        public string TeamName { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public Player Player { get; set; }

    }
}
