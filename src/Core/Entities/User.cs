using Farmify_API_v2.src.Core.Enums;

namespace Farmify_API_v2.src.Core.Entities
{
    public class User
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string Username { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public UserStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User() { }

        public User(DateTime now)
        {
            Status = UserStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetProfile(string firstName, string lastName, string username, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
        }

        public void Update(string firstName, string lastName, string email, string username, DateTime now)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            CreatedAt = now;
        }

        public void SetStatus(UserStatus status) => Status = status;
    }
}
