namespace Farmify_API_v2.src.Core.Entities
{
    public class User
    {
        public int ID { get; private set; }
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string Username { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private User() { }

        public User(string firstName, string lastName, string email, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void Update(string firstName, string lastName, string email, string username)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
        }

        public void Deactivate() => IsActive = false;
    }
}
