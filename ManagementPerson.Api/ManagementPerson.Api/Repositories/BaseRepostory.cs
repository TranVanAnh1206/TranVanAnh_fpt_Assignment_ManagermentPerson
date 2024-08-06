
using ManagementPerson.Api.Data;
using ManagementPerson.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ManagementPerson.Api.Repositories
{
    public class BaseRepostory<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ManagerPersionDbContext _dbContext;

        public BaseRepostory(ManagerPersionDbContext dbContext)
        {
            _dbContext = dbContext;
            
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var res = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            _dbContext.Set<TEntity>().Remove(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbContext.Set<TEntity>().Include(includes.First());
                foreach( var include in includes.Skip(1)) 
                    query = query.Include(include);

                return await query.ToListAsync();
            }

            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById(int id, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = _dbContext.Set<TEntity>().Include(includes.First());

                return (TEntity)query;
            }

                return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                return 0;

            _dbContext.Set<TEntity>().Update(entity);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
