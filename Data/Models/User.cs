namespace BlazerServerCoaching.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public User(string name)
        {
            Name = name;
        }
    }


}
