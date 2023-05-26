namespace Online_Tests_API.Data.EntityRepository
{
    public interface IRepository<TContext, TEntity>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}