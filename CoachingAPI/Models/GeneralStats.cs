using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoachingAPI.Models
{
    public class GeneralStats
    {
        [Key]
        public Guid Id { get; set; }

        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int KDRatio { get; set; }
        public int KRRatio { get; set; }
        public int Headshots { get; set; }

        // Navigation property
        //public Guid PlayerGuid { get; set; }

        public List<MapStats> MapStats { get; set; } = new();
        //[ForeignKey(nameof(PlayerGuid))]
        //public Player RelatedPlayer { get; set; }
    }
}