using Microsoft.OpenApi.Models;
using Online_Tests_API.Data.EntityRepository;
using Microsoft.EntityFrameworkCore;
using Online_Tests_API.Data;
using Online_Tests_API.Services.Exam;
using Online_Tests_API.Services.Institution;

namespace Online_Tests_API.Extensions
{
    public static class ServiceExtension
    {
        public static void SetupCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void SetupIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {
            });
        }

        public static void SetupServices(this IServiceCollection services, IWebHostEnvironment Environment, IConfiguration configuration)
        {
            var environment = configuration["Environment"];
            var OnlineTestsRepositoryConnection = configuration.GetConnectionString($"OnlineTestsDB_{environment}");

            services.AddDbContext<OnlineTestsDbContext>(options => options.UseSqlServer(OnlineTestsRepositoryConnection));

            services.AddTransient<IQuestionPapersRepository, QuestionPapersRepository>();
            services.AddTransient<IQuestionsRepository, QuestionsRepository>();
            services.AddTransient<IOptionsRepository, OptionsRepository>();
            services.AddTransient<IBranchesAndSectionsForTestRepository, BranchesAndSectionsForTestRepository>();
            services.AddTransient<IQuestionPaperSectionRepository, QuestionPaperSectionRepository>();
            services.AddTransient<IBranchesRepository, BranchesRepository>();
            services.AddTransient<ISectionsRepository, SectionsRepository>();

            services.AddTransient<IQuestionPaperService, QuestionPaperService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IOptionsService, OptionsService>();
            services.AddTransient<IBranchAndSectionService, BranchAndSectionService>();
            services.AddTransient<IQuestionPaperSectionService, QuestionPaperSectionService>();
            services.AddTransient<IBranchesService, BranchesService>();
            services.AddTransient<ISectionsService, SectionsService>();
        }

        public static void SetupSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Online Tests", Version = "v1" });
            });
        }

    }
}
