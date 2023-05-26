using Online_Tests_API.Data;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public class QuestionPaperSectionService : IQuestionPaperSectionService
    {
        private readonly IQuestionPaperSectionRepository _repository;
        public QuestionPaperSectionService(IQuestionPaperSectionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionPaperSectionEntity>> GetAllQuestionPaperSections()
        {
            return await _repository.GetAllQuestionPaperSectionsAsync();
        }

        public async Task<QuestionPaperSectionEntity> CreateQuestionPaperSection(QuestionPaperSectionEntity questionPaperSection)
        {
            return await _repository.CreateQuestionPaperSectionAsync(questionPaperSection);
        }

        public async Task<QuestionPaperSectionEntity> UpdateQuestionPaperSection(QuestionPaperSectionEntity questionPaperSection)
        {
            return await _repository.UpdateQuestionPaperSectionAsync(questionPaperSection);
        }

        public async Task<QuestionPaperSectionEntity> DeleteQuestionPaperSection(QuestionPaperSectionEntity questionPaperSection)
        {
            return await _repository.DeleteQuestionPaperSectionAsync(questionPaperSection);
        }
    }
}
