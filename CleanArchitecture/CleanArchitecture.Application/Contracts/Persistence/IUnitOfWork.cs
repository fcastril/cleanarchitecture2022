using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;

        /*
            Para Personalización de Repositorios
            
            IPersonalRepository PersonalRepositoy { get; }

        */
        Task<int> Complete();
    }
}
