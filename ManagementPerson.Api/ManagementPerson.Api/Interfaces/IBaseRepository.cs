
namespace ManagementPerson.Api.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync(string[] includes = null);
        Task<TEntity> GetById(int id, string[] includes = null);
    }
}
