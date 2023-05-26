using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public interface IQuestionPaperSectionRepository
    {
        Task<QuestionPaperSectionEntity> CreateQuestionPaperSectionAsync(QuestionPaperSectionEntity questionPaperSection);
        Task<QuestionPaperSectionEntity> DeleteQuestionPaperSectionAsync(QuestionPaperSectionEntity questionPaperSection);
        Task<IEnumerable<QuestionPaperSectionEntity>> GetAllQuestionPaperSectionsAsync();
        Task<QuestionPaperSectionEntity> UpdateQuestionPaperSectionAsync(QuestionPaperSectionEntity questionPaperSection);
    }
}