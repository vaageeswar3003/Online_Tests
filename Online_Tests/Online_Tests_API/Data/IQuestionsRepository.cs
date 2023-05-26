using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public interface IQuestionsRepository
    {
        Task<QuestionEntity> CreateQuestionAsync(QuestionEntity question);
        Task<QuestionEntity> DeleteQuestionAsync(QuestionEntity question);
        Task<IEnumerable<QuestionEntity>> GetAllQuestionsAsync();
        Task<QuestionEntity> UpdateQuestionAsync(QuestionEntity question);
    }
}