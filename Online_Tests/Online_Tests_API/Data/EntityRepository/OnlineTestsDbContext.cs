using Microsoft.EntityFrameworkCore;
using Online_Tests_API.Entities;

namespace Online_Tests_API.Data.EntityRepository
{
    public class OnlineTestsDbContext: DbContext
    {
        public OnlineTestsDbContext(DbContextOptions<OnlineTestsDbContext> options): base(options) { }

        public DbSet<QuestionPaperEntity> QuestionPaper { get; set; }
        public DbSet<QuestionEntity> Question { get; set; }
        public DbSet<OptionsEntity> Options { get; set; }
        public DbSet<BranchesAndSectionsForTestEntity> BranchesAndSectionsForTest { get; set; }
        public DbSet<QuestionPaperSectionEntity> QuestionPaperSection { get; set; }
        public DbSet<BranchesEntity> BranchesEntity { get; set; }
    }
}
