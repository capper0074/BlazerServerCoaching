namespace CoachingAPI.Models.DTOs
{
    public class TeamDTO(string name, bool isMatchMaking)
    {
        public string Name { get; set; } = name;
        public bool IsMatchMaking { get; set; } = isMatchMaking;
    }
}
