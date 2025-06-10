namespace ASP_NET_Quiz.Components.Data
{
    using Microsoft.EntityFrameworkCore;
    using ASP_NET_Quiz.Components.Models;

    public class QuizDBContext : DbContext
    {
        public QuizDBContext(DbContextOptions<QuizDBContext> options) : base(options) { }
        public DbSet<QuizQuestionsModel> QuizQuestions { get; set; } = null!;
        public DbSet<QuizOptionModel> QuizOptions { get; set; } = null!;
        public DbSet<QuizResponseModel> QuizResponses { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuizQuestionsModel>().ToTable("QuizQuestions");
            modelBuilder.Entity<QuizOptionModel>().ToTable("QuizOptions");
        }
    }
}
