namespace CoachingAPI.Models
{
    public class PlayerStats
    {
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int KDRatio { get; set; }
        public int KRRatio { get; set; }
        public int Headshots { get; set; }
    }
}