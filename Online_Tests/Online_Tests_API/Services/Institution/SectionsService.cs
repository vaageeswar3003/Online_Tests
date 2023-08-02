using Online_Tests_API.Data;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Institution
{
    public class SectionsService : ISectionsService
    {
        private ISectionsRepository _repository;

        public SectionsService(ISectionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SectionsEntity>> GetSectionsByBranchId(int branchId)
        {
            return await _repository.GetSectionsByBranchIdAsync(branchId);
        }
        public async Task<SectionsEntity> AddSectionToBranch(SectionsEntity section)
        {
            return await _repository.AddSectionToBranchAsync(section);
        }
        public async Task<SectionsEntity> UpdateSectionInBranch(SectionsEntity section)
        {
            return await _repository.UpdateSectionInBranchAsync(section);
        }
        public async Task<SectionsEntity> DeleteSectionInBranch(SectionsEntity section)
        {
            return await _repository.DeleteSectionInBranchAsync(section);
        }
    }
}
