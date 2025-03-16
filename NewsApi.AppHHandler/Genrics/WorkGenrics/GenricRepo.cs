using Microsoft.EntityFrameworkCore;
using NewsApi.AppHandler.Genrics.Intrefaces;
using NewsApi.Infastrcture.AppInfa;
using NewsAPI.Domain.AppEntity;

namespace NewsApi.AppHandler.Genrics.WorkGenrics
{
    public class GenricRepo<T> : IGenricRepo<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;

        public GenricRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T item)
        => await _dbContext.Set<T>().AddAsync(item);

        public void DeleteAsync(T item)
        {
            _dbContext.Remove(item);
        }

        public async Task<IEnumerable<T>> GetAllWithAsync() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();

        public async Task<T?> GetbyIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);

        public void Update(T item)
        {
            _dbContext.Update(item);
        }
    }
}