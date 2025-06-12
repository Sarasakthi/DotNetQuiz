using Microsoft.EntityFrameworkCore;
using ASP_NET_Quiz.Components.Models;

namespace ASP_NET_Quiz.Components.Data
{
    public class QuizDBContext : DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options) { }

        public DbSet<QuizQuestionsModel> QuizQuestions { get; set; } = null!;
        public DbSet<QuizOptionsModel> QuizOptions { get; set; } = null!;
        public DbSet<QuizResponseModel> QuizResponses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizQuestionsModel>()
                .ToTable("QuizQuestions")
                .HasMany(q => q.Options)
                .WithOne(o => o.Question)
                .HasForeignKey(o => o.QuestionNumber);

            modelBuilder.Entity<QuizOptionsModel>().ToTable("QuizOptions");

            modelBuilder.Entity<QuizResponseModel>().ToTable("QuizResponses");
        }
    }

}
