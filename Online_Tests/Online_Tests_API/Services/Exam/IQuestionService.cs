using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public interface IQuestionService
    {
        Task<QuestionEntity> CreateQuestion(QuestionEntity question);
        Task<QuestionEntity> DeleteQuestion(QuestionEntity question);
        Task<IEnumerable<QuestionEntity>> GetAllQuestions();
        Task<QuestionEntity> UpdateQuestion(QuestionEntity question);
    }
}