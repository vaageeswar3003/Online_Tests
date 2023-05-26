using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public interface IQuestionPaperService
    {
        Task<QuestionPaperEntity> CreateQuestionPaper(QuestionPaperEntity questionPaper);
        Task<QuestionPaperEntity> DeleteQuestionPaper(QuestionPaperEntity questionPaper);
        Task<IEnumerable<QuestionPaperEntity>> GetAllQuestionPapers();
        Task<QuestionPaperEntity> UpdateQuestionPaper(QuestionPaperEntity questionPaper);
    }
}