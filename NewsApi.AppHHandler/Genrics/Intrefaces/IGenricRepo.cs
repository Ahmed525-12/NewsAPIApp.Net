using NewsAPI.Domain.AppEntity;

namespace NewsApi.AppHandler.Genrics.Intrefaces
{
    public interface IGenricRepo<T> where T : BaseEntity
    {
        Task<T> GetbyIdAsync(int id);

        Task<IEnumerable<T>> GetAllWithAsync();

        Task AddAsync(T item);

        void DeleteAsync(T item);

        void Update(T item);
    }
}