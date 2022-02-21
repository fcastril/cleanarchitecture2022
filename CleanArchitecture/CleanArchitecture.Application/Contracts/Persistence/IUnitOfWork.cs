using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        Task<int> Complete();
    }
}
