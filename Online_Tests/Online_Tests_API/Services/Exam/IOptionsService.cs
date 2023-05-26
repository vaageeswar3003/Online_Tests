using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public interface IOptionsService
    {
        Task<OptionsEntity> CreateOption(OptionsEntity option);
        Task<OptionsEntity> DeleteOption(OptionsEntity option);
        Task<IEnumerable<OptionsEntity>> GetAllOptions();
        Task<OptionsEntity> UpdateOption(OptionsEntity option);
    }
}