using NewsApi.AppHandler.Genrics.Intrefaces;
using NewsApi.AppHandler.Genrics.WorkGenrics;
using NewsApi.Infastrcture.AppInfa;
using NewsAPI.Domain.AppEntity;
using System.Collections;

namespace HospitalAPP.Genrics.WorkGenrics
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private Hashtable Repo;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            Repo = new Hashtable();
        }

        public async Task<int> CompleteAsync()
            => await _dbContext.SaveChangesAsync();

        public ValueTask DisposeAsync()
        => _dbContext.DisposeAsync();

        public IGenricRepo<T> Repository<T>() where T : BaseEntity
        {
            var type = typeof(T).Name;
            if (!Repo.ContainsKey(type))
            {
                var repository = new GenricRepo<T>(_dbContext);
                Repo.Add(type, repository);
            }
            return (IGenricRepo<T>)Repo[type]!;
        }
    }
}