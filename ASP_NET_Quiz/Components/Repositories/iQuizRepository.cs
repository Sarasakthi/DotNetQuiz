using ASP_NET_Quiz.Components.Models;

namespace ASP_NET_Quiz.Components.Repository
{
    public interface iQuizRepository
    {
        Task<List<QuizQuestionsModel>> GetAllQuestionsAsync();
        Task<QuizQuestionsModel> GetQuestionByNumberAsync(int questionNumber);
        Task<List<QuizQuestionsModel>> GetQuestionsRandomByNumberOfQuestions(int numberOfQuestions);
        Task<bool> SaveQuizResponseAsync(QuizResponseModel quizResponseModel);
    }
}
