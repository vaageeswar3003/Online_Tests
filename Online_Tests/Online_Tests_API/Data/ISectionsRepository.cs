using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public interface ISectionsRepository
    {
        Task<SectionsEntity> AddSectionToBranchAsync(SectionsEntity section);
        Task<SectionsEntity> DeleteSectionInBranchAsync(SectionsEntity section);
        Task<IEnumerable<SectionsEntity>> GetSectionsByBranchIdAsync(int branchId);
        Task<SectionsEntity> UpdateSectionInBranchAsync(SectionsEntity section);
    }
}