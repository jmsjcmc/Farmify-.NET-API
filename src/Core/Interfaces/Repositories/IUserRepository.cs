using Farmify_API_v2.src.Core.Entities;

namespace Farmify_API_v2.src.Core.Interfaces.Repositories
{
   public interface IUserRepository
    {
        Task<User?> GetByIDAsync(int id, CancellationToken ct);
        Task<User?> GetByUsernameAsync(string username, CancellationToken ct);
        Task<User?> GetByEmailAsync(string email, CancellationToken ct);
        Task<List<User>> GetAllAsync(CancellationToken ct);
        Task AddAsync(User user, CancellationToken ct);
        void Remove(User user);
    }
}
