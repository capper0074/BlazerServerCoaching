namespace CoachingAPI.Models.DTOs
{
    public class PlayerDTO(string name)
    {
        public string Name { get; set; } = name;
    }
}
