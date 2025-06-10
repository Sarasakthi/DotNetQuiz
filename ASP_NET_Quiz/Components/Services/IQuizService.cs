namespace ASP_NET_Quiz.Components.Services
{
    using ASP_NET_Quiz.Components.Models;
    public interface IQuizService
    {
        Task<List<QuizQuestionsModel>> GetAllQuestionsAsync();
        Task<QuizQuestionsModel> GetQuestionByNumberAsync(int questionNumber);
        Task<List<QuizQuestionsModel>> GetQuestionsRandomByNumberOfQuestions(int numberOfQuestions);
        Task<bool> SaveQuizResponseAsync(QuizResponseModel quizResponseModel);
    }
}
