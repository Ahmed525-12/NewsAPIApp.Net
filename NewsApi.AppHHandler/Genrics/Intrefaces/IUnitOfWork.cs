using NewsAPI.Domain.AppEntity;

namespace NewsApi.AppHandler.Genrics.Intrefaces
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<int> CompleteAsync();

        IGenricRepo<T> Repository<T>() where T : BaseEntity;

        void Detach<T>(T entity) where T : BaseEntity;
    }
}