using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public class BranchesAndSectionsForTestRepository : Repository<OnlineTestsDbContext, BranchesAndSectionsForTestEntity>, IBranchesAndSectionsForTestRepository
    {
        public BranchesAndSectionsForTestRepository(OnlineTestsDbContext context) : base(context) { }

        public async Task<IEnumerable<BranchesAndSectionsForTestEntity>> GetAllBranchesAndSectionsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<BranchesAndSectionsForTestEntity> CreateBrancheAndSectionAsync(BranchesAndSectionsForTestEntity branchAndSection)
        {
            return await AddAsync(branchAndSection);
        }

        public async Task<BranchesAndSectionsForTestEntity> UpdateBrancheAndSectionAsync(BranchesAndSectionsForTestEntity branchAndSection)
        {
            return await UpdateAsync(branchAndSection);
        }

        public async Task<BranchesAndSectionsForTestEntity> DeleteBrancheAndSectionAsync(BranchesAndSectionsForTestEntity branchAndSection)
        {
            return await DeleteAsync(branchAndSection);
        }
    }
}
