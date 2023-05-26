using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public class OptionsRepository : Repository<OnlineTestsDbContext, OptionsEntity>, IOptionsRepository
    {
        public OptionsRepository(OnlineTestsDbContext context) : base(context) { }

        public async Task<IEnumerable<OptionsEntity>> GetAllOptionsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<OptionsEntity> CreateOptionAsync(OptionsEntity option)
        {
            return await AddAsync(option);
        }

        public async Task<OptionsEntity> UpdateOptionAsync(OptionsEntity option)
        {
            return await UpdateAsync(option);
        }

        public async Task<OptionsEntity> DeleteOptionAsync(OptionsEntity option)
        {
            return await DeleteAsync(option);
        }


    }
}
