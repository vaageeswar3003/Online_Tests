using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public interface IBranchesRepository
    {
        Task<BranchesEntity> AddBranchToInstitutionAsync(BranchesEntity branch);
        Task<BranchesEntity> DeleteBranchInInstitutionAsync(BranchesEntity branch);
        Task<IEnumerable<BranchesEntity>> GetBranchesByInstitutionIdAsync(int institutionId);
        Task<BranchesEntity> UpdateBranchInInstitutionAsync(BranchesEntity branch);
    }
}