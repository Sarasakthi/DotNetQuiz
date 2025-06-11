using ASP_NET_Quiz.Components.Data;
using Microsoft.EntityFrameworkCore;
using ASP_NET_Quiz.Components.Models;

namespace ASP_NET_Quiz.Components.Repository
{
    public class QuizRepository : iQuizRepository
    {
        private readonly QuizDBContext _context;

        public QuizRepository(QuizDBContext context)
        {
            _context = context;
        }

        public async Task<List<QuizQuestionsModel>> GetAllQuestionsAsync()
        {
            return await _context.QuizQuestions
                .Include(q => q.Options)
                .ToListAsync();
        }

        public async Task<QuizQuestionsModel> GetQuestionByNumberAsync(int questionNumber)
        {
            return await _context.QuizQuestions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.QuestionNumber == questionNumber)
                ?? new QuizQuestionsModel
                {
                    Question = string.Empty,
                    CorrectResponse = string.Empty,
                    Explanation = string.Empty
                };
        }

        public async Task<List<QuizQuestionsModel>> GetQuestionsRandomByNumberOfQuestions(int numberOfQuestions)
        {
            return await _context.QuizQuestions
                .Include(q => q.Options)
                .OrderBy(q => Guid.NewGuid())
                .Take(numberOfQuestions)
                .ToListAsync();
        }

        public async Task<bool> SaveQuizResponseAsync(QuizResponseModel quizResponseModel)
        {
            try
            {
                _context.QuizResponses.Add(quizResponseModel);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                // Log exception if needed
                return false;
            }
        }
    }
}
