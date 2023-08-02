using Microsoft.EntityFrameworkCore;
using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public class BranchesAndSectionsForTestRepository : Repository<OnlineTestsDbContext, BranchesAndSectionsForTestEntity>, IBranchesAndSectionsForTestRepository
    {
        private readonly OnlineTestsDbContext _context;
        public BranchesAndSectionsForTestRepository(OnlineTestsDbContext context) : base(context) { 
            _context = context;
        }

        public async Task<IEnumerable<BranchesAndSectionsForTestEntity>> GetAllBranchesAndSectionsByQuestionPaperIdAsync(int questionPaperId)
        {
            return await _context.BranchesAndSectionsForTest.Where(record => record.QuestionPaperId == questionPaperId).ToListAsync();
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
