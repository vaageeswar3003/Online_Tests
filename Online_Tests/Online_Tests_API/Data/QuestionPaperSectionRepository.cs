using Microsoft.EntityFrameworkCore;
using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public class QuestionPaperSectionRepository : Repository<OnlineTestsDbContext, QuestionPaperSectionEntity>, IQuestionPaperSectionRepository
    {
        private readonly OnlineTestsDbContext _context;
        public QuestionPaperSectionRepository(OnlineTestsDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionPaperSectionEntity>> GetAllQuestionPaperSectionsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<IEnumerable<QuestionPaperSectionEntity>> GetQuestionPaperSectionsByQuestionPaperIdAsync(int questionPaperId)
        {
            return await _context.QuestionPaperSection.Where(record => record.QuestionPaperId == questionPaperId).ToListAsync();
        }

        public async Task<QuestionPaperSectionEntity> CreateQuestionPaperSectionAsync(QuestionPaperSectionEntity questionPaperSection)
        {
            return await AddAsync(questionPaperSection);
        }

        public async Task<QuestionPaperSectionEntity> UpdateQuestionPaperSectionAsync(QuestionPaperSectionEntity questionPaperSection)
        {
            return await UpdateAsync(questionPaperSection);
        }

        public async Task<QuestionPaperSectionEntity> DeleteQuestionPaperSectionAsync(QuestionPaperSectionEntity questionPaperSection)
        {
            return await DeleteAsync(questionPaperSection);
        }
    }
}
