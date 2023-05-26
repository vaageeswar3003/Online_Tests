using Online_Tests_API.Data;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public class OptionsService : IOptionsService
    {
        private readonly IOptionsRepository _repository;
        public OptionsService(IOptionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<OptionsEntity>> GetAllOptions()
        {
            return await _repository.GetAllOptionsAsync();
        }

        public async Task<OptionsEntity> CreateOption(OptionsEntity option)
        {
            return await _repository.CreateOptionAsync(option);
        }

        public async Task<OptionsEntity> UpdateOption(OptionsEntity option)
        {
            return await _repository.UpdateOptionAsync(option);
        }

        public async Task<OptionsEntity> DeleteOption(OptionsEntity option)
        {
            return await _repository.DeleteOptionAsync(option);
        }
    }
}
