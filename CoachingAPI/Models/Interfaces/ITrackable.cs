namespace CoachingAPI.Models.Interfaces
{
    public interface ITrackable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
