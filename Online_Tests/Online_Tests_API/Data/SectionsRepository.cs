using Microsoft.EntityFrameworkCore;
using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public class SectionsRepository : Repository<OnlineTestsDbContext, SectionsEntity>, ISectionsRepository
    {
        private OnlineTestsDbContext _context;
        public SectionsRepository(OnlineTestsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SectionsEntity>> GetSectionsByBranchIdAsync(int branchId)
        {
            return await _context.SectionsEntity.Where(section => section.BranchId == branchId).ToListAsync();
        }

        public async Task<SectionsEntity> AddSectionToBranchAsync(SectionsEntity section)
        {
            return await AddAsync(section);
        }
        public async Task<SectionsEntity> UpdateSectionInBranchAsync(SectionsEntity section)
        {
            return await UpdateAsync(section);
        }
        public async Task<SectionsEntity> DeleteSectionInBranchAsync(SectionsEntity section)
        {
            return await DeleteAsync(section);
        }
    }
}
