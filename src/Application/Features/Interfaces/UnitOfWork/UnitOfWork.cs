namespace Farmify_API_v2.src.Application.Features.Interfaces.UnitOfWork
{
   public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbConte
    }
}
