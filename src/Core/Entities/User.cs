using BCrypt.Net;
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
        public string PasswordHash { get; private set; } = default!;
        public UserStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User() { }

        public User(DateTime now)
        {
            Status = UserStatus.Active;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetProfile(string firstName, string lastName, string username, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            PasswordHash = HashPassword(password);
        }

        private string HashPassword(string password) => BCrypt.Net.BCrypt.HashPassword(password);
        public bool CheckPassword(string password) => BCrypt.Net.BCrypt.Verify(password, PasswordHash);

        public void Update(string firstName, string lastName, string email, string username, DateTime now)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            CreatedAt = now;
        }

        public void SetStatus(UserStatus status) => Status = status;
        public void ChangePassword(string newPassword) => PasswordHash = HashPassword(newPassword);
    }
}
