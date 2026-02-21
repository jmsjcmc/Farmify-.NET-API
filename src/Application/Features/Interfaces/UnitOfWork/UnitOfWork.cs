using Farmify_API_v2.src.Infrastructure.Persistence.Context;

namespace Farmify_API_v2.src.Application.Features.Interfaces.UnitOfWork
{
   public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context) => _context = context;

        public Task<int> SaveChangesAsync(CancellationToken ct) => _context.SaveChangesAsync(ct);
    }
}
