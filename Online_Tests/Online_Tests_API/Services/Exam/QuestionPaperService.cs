using Online_Tests_API.Data;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public class QuestionPaperService : IQuestionPaperService
    {
        private readonly IQuestionPapersRepository _repository;
        public QuestionPaperService(IQuestionPapersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionPaperEntity>> GetAllQuestionPapers()
        {
            var questionPapers = await _repository.GetAllQuestionPapersAsync();
            return questionPapers;
        }

        public async Task<QuestionPaperEntity> CreateQuestionPaper(QuestionPaperEntity questionPaper)
        {
            return await _repository.CreateQuestionPaperAsync(questionPaper);
        }

        public async Task<QuestionPaperEntity> UpdateQuestionPaper(QuestionPaperEntity questionPaper)
        {
            return await _repository.UpdateQuestionPaperAsync(questionPaper);
        }

        public async Task<QuestionPaperEntity> DeleteQuestionPaper(QuestionPaperEntity questionPaper)
        {
            return await _repository.DeleteQuestionPaperAsync(questionPaper);
        }
    }
}
