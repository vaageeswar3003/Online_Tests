using Online_Tests_API.Data;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public class BranchAndSectionService : IBranchAndSectionService
    {
        private readonly IBranchesAndSectionsForTestRepository _repository;

        public BranchAndSectionService(IBranchesAndSectionsForTestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BranchesAndSectionsForTestEntity>> GetAllBranchesAndSections()
        {
            return await _repository.GetAllBranchesAndSectionsAsync();
        }

        public async Task<BranchesAndSectionsForTestEntity> CreateBranchAndSection(BranchesAndSectionsForTestEntity branchAndSection)
        {
            return await _repository.CreateBrancheAndSectionAsync(branchAndSection);
        }

        public async Task<BranchesAndSectionsForTestEntity> UpdateBranchAndSection(BranchesAndSectionsForTestEntity branchAndSection)
        {
            return await _repository.UpdateBrancheAndSectionAsync(branchAndSection);
        }

        public async Task<BranchesAndSectionsForTestEntity> DeleteBranchAndSection(BranchesAndSectionsForTestEntity branchAndSection)
        {
            return await _repository.DeleteBrancheAndSectionAsync(branchAndSection);
        }
    }
}
