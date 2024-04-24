using CoachingAPI.Models.Interfaces;

namespace CoachingAPI.Models.DTOs
{
    public class GeneralStatsDTO(ITrackable target, List<MapStatsDTO> mapStats)
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int KDRatio { get; set; }
        public int KRRatio { get; set; }
        public int Headshots { get; set; }

        public ITrackable Target { get; set; } = target;
        public List<MapStatsDTO> MapStats { get; set; } = mapStats;
    }
}