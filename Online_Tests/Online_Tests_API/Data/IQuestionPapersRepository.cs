using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public interface IQuestionPapersRepository
    {
        Task<QuestionPaperEntity> CreateQuestionPaperAsync(QuestionPaperEntity questionPaper);
        Task<QuestionPaperEntity> DeleteQuestionPaperAsync(QuestionPaperEntity questionPaper);
        Task<IEnumerable<QuestionPaperEntity>> GetAllQuestionPapersAsync();
        Task<QuestionPaperEntity> UpdateQuestionPaperAsync(QuestionPaperEntity questionPaper);
    }
}