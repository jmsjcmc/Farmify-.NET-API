using Farmify_API_v2.src.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Farmify_API_v2.src.Infrastructure.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
