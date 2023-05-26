using Microsoft.EntityFrameworkCore;
using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public class BranchesRepository : Repository<OnlineTestsDbContext, BranchesEntity>, IBranchesRepository
    {
        private OnlineTestsDbContext _context;
        public BranchesRepository(OnlineTestsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BranchesEntity>> GetBranchesByInstitutionIdAsync(int institutionId)
        {
            return await _context.BranchesEntity.Where(branch => branch.InstitutionId == institutionId).ToListAsync();
        }

        public async Task<BranchesEntity> AddBranchToInstitutionAsync(BranchesEntity branch)
        {
            return await AddAsync(branch);
        }

        public async Task<BranchesEntity> UpdateBranchInInstitutionAsync(BranchesEntity branch)
        {
            return await UpdateAsync(branch);
        }
        public async Task<BranchesEntity> DeleteBranchInInstitutionAsync(BranchesEntity branch)
        {
            return await DeleteAsync(branch);
        }
    }
}
