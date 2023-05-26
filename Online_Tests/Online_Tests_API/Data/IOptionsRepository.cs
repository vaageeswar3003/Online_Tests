using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public interface IOptionsRepository
    {
        Task<OptionsEntity> CreateOptionAsync(OptionsEntity option);
        Task<OptionsEntity> DeleteOptionAsync(OptionsEntity option);
        Task<IEnumerable<OptionsEntity>> GetAllOptionsAsync();
        Task<OptionsEntity> UpdateOptionAsync(OptionsEntity option);
    }
}