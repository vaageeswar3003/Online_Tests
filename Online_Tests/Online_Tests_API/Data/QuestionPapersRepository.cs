using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;
using Online_Tests_API.Models;

namespace Online_Tests_API.Data
{
    public class QuestionPapersRepository : Repository<OnlineTestsDbContext, QuestionPaperEntity>, IQuestionPapersRepository
    {
        public QuestionPapersRepository(OnlineTestsDbContext context) : base(context) { }

        public async Task<IEnumerable<QuestionPaperEntity>> GetAllQuestionPapersAsync()
        {
            return await GetAllAsync();
        }

        public async Task<QuestionPaperEntity> CreateQuestionPaperAsync(QuestionPaperEntity questionPaper)
        {
            return await AddAsync(questionPaper);
        }

        public async Task<QuestionPaperEntity> UpdateQuestionPaperAsync(QuestionPaperEntity questionPaper)
        {
            return await UpdateAsync(questionPaper);
        }

        public async Task<QuestionPaperEntity> DeleteQuestionPaperAsync(QuestionPaperEntity questionPaper)
        {
            return await DeleteAsync(questionPaper);
        }
    }
}
