using System.ComponentModel.DataAnnotations;


namespace BlazerServerCoaching.Data.Models
{
    public class Team
    {
        [Key]
        public int? Id { get; set; }
        public string? TeamName { get; set; }
        public string TeamDescription { get; set; } = string.Empty;
        public User? Coach {  get; set; }
        public User? Player_1 { get; set; }
        public User? Player_2 { get; set; }
        public User? Player_3 { get; set; }
        public User? Player_4 { get; set; }
        public User? Player_5 { get; set; }

    }
}
