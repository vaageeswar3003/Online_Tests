using Online_Tests_API.Entities;

namespace Online_Tests_API.Services.Exam
{
    public interface IQuestionPaperSectionService
    {
        Task<QuestionPaperSectionEntity> CreateQuestionPaperSection(QuestionPaperSectionEntity questionPaperSection);
        Task<QuestionPaperSectionEntity> DeleteQuestionPaperSection(QuestionPaperSectionEntity questionPaperSection);
        Task<IEnumerable<QuestionPaperSectionEntity>> GetAllQuestionPaperSections();
        Task<IEnumerable<QuestionPaperSectionEntity>> GetQuestionPaperSectionsByQuestionPaperId(int questionPaperId);
        Task<QuestionPaperSectionEntity> UpdateQuestionPaperSection(QuestionPaperSectionEntity questionPaperSection);
    }
}