using Microsoft.EntityFrameworkCore;

namespace Online_Tests_API.Data.EntityRepository
{
    public class Repository<TContext, TEntity> : IRepository<TContext, TEntity>
        where TEntity : class, new()
        where TContext: DbContext
    {

        private readonly TContext _dbContext;
        public Repository(TContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity must not be null");
            }
            else
            {
                try
                {
                    await _dbContext.AddAsync(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity must not be null");
            }
            else
            {
                try
                {
                    _dbContext.Update(entity);
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity must not be null");
            }
            else
            {
                try
                {
                    _dbContext.Entry(entity).State = EntityState.Deleted;
                    await _dbContext.SaveChangesAsync();
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
