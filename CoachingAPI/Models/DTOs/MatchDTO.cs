namespace CoachingAPI.Models.DTOs
{
    public class MatchDTO(DateTime date, MatchPlatform matchPlatform, MapName mapName, int winnerTeamId, List<int> teamIds)
    {
        public DateTime Date { get; set; } = date;
        public MatchPlatform MatchPlatform { get; set; } = matchPlatform;

        // Foreign keys
        public MapName MapName { get; set; } = mapName;
        public int WinnerTeamId { get; set; } = winnerTeamId;
        public List<int> TeamIds { get; set; } = teamIds;
    }
}
