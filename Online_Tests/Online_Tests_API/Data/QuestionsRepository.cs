using Online_Tests_API.Data.EntityRepository;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data
{
    public class QuestionsRepository : Repository<OnlineTestsDbContext, QuestionEntity>, IQuestionsRepository
    {
        public QuestionsRepository(OnlineTestsDbContext context) : base(context) { }

        public async Task<IEnumerable<QuestionEntity>> GetAllQuestionsAsync()
        {
            return await GetAllAsync();
        }

        public async Task<QuestionEntity> CreateQuestionAsync(QuestionEntity question)
        {
            return await AddAsync(question);
        }

        public async Task<QuestionEntity> UpdateQuestionAsync(QuestionEntity question)
        {
            return await UpdateAsync(question);
        }

        public async Task<QuestionEntity> DeleteQuestionAsync(QuestionEntity question)
        {
            return await DeleteAsync(question);
        }
    }
}
