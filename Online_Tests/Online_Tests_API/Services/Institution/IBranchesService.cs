using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Institution
{
    public interface IBranchesService
    {
        Task<BranchesEntity> AddBranchToInstitution(BranchesEntity branch);
        Task<BranchesEntity> DeleteBranchInInstitution(BranchesEntity branch);
        Task<IEnumerable<BranchesEntity>> GetBranchesByInstitutionId(int institutionId);
        Task<BranchesEntity> UpdateBranchInInstitution(BranchesEntity branch);
    }
}