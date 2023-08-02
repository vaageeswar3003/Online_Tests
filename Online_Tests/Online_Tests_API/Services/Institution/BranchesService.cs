using Online_Tests_API.Data;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Institution
{
    public class BranchesService : IBranchesService
    {
        private IBranchesRepository _repository;

        public BranchesService(IBranchesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BranchesEntity>> GetBranchesByInstitutionId(int institutionId)
        {
            return await _repository.GetBranchesByInstitutionIdAsync(institutionId);
        }
        public async Task<BranchesEntity> AddBranchToInstitution(BranchesEntity branch)
        {
            return await _repository.AddBranchToInstitutionAsync(branch);
        }
        public async Task<BranchesEntity> UpdateBranchInInstitution(BranchesEntity branch)
        {
            return await _repository.UpdateBranchInInstitutionAsync(branch);
        }
        public async Task<BranchesEntity> DeleteBranchInInstitution(BranchesEntity branch)
        {
            return await _repository.DeleteBranchInInstitutionAsync(branch);
        }
    }
}
