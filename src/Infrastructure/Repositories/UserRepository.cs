using Farmify_API_v2.src.Core.Entities;
using Farmify_API_v2.src.Core.Interfaces.Repositories;
using Farmify_API_v2.src.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Farmify_API_v2.src.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(User user, CancellationToken ct) => await _context.Users.AddAsync(user, ct);
        public async Task<(List<User>, int)> GetPagedAsync(
            int page,
            int pageSize,
            CancellationToken ct)
        {
            var query = _context.Users.AsNoTracking();
            var total = await query.CountAsync(ct);
            var items = await query
                .OrderByDescending(U => U.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(ct);

            return (items, total);

        }
        public async Task<List<User>> GetAllAsync(CancellationToken ct) => await _context.Users.AsNoTracking().ToListAsync(ct);
        public async Task<User?> GetByIDAsync(int id, CancellationToken ct) => await _context.Users.FindAsync([id], ct);
        public async Task<User?> GetByEmailAsync(string email, CancellationToken ct) => await _context.Users.FirstOrDefaultAsync(x => x.Email == email, ct);
        public async Task<User?> GetByUsernameAsync(string username, CancellationToken ct) => await _context.Users.FirstOrDefaultAsync(x => x.Username == username, ct);
        public void Remove(User user) => _context.Users.Remove(user);
    }
}
