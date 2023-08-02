using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public interface IBranchesAndSectionsForTestRepository
    {
        Task<BranchesAndSectionsForTestEntity> CreateBrancheAndSectionAsync(BranchesAndSectionsForTestEntity branchAndSection);
        Task<BranchesAndSectionsForTestEntity> DeleteBrancheAndSectionAsync(BranchesAndSectionsForTestEntity branchAndSection);
        Task<IEnumerable<BranchesAndSectionsForTestEntity>> GetAllBranchesAndSectionsByQuestionPaperIdAsync(int questionPaperId);
        Task<BranchesAndSectionsForTestEntity> UpdateBrancheAndSectionAsync(BranchesAndSectionsForTestEntity branchAndSection);
    }
}