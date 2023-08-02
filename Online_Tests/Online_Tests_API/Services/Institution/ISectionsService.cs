using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Institution
{
    public interface ISectionsService
    {
        Task<SectionsEntity> AddSectionToBranch(SectionsEntity section);
        Task<SectionsEntity> DeleteSectionInBranch(SectionsEntity section);
        Task<IEnumerable<SectionsEntity>> GetSectionsByBranchId(int branchId);
        Task<SectionsEntity> UpdateSectionInBranch(SectionsEntity section);
    }
}