namespace Domain.Models
{
    public class User
    {
        public User(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
        public string Name { get; set; }
    }
}
