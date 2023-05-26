using Online_Tests_API.Data;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionsRepository _repository;
        public QuestionService(IQuestionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<QuestionEntity>> GetAllQuestions()
        {
            return await _repository.GetAllQuestionsAsync();
        }

        public async Task<QuestionEntity> CreateQuestion(QuestionEntity question)
        {
            return await _repository.CreateQuestionAsync(question);
        }

        public async Task<QuestionEntity> UpdateQuestion(QuestionEntity question)
        {
            return await _repository.UpdateQuestionAsync(question);
        }

        public async Task<QuestionEntity> DeleteQuestion(QuestionEntity question)
        {
            return await _repository.DeleteQuestionAsync(question);
        }
    }
}
