using ASP_NET_Quiz.Components.Models;
using ASP_NET_Quiz.Components.Repository;

namespace ASP_NET_Quiz.Components.Services
{
    public class QuizService : IQuizService
    {
        private readonly iQuizRepository _quizRepository;
        public QuizService(iQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<List<QuizQuestionsModel>> GetAllQuestionsAsync()
        {
            return await _quizRepository.GetAllQuestionsAsync();
        }
        public async Task<QuizQuestionsModel> GetQuestionByNumberAsync(int questionNumber)
        {
            return await _quizRepository.GetQuestionByNumberAsync(questionNumber);
        }
        public async Task<List<QuizQuestionsModel>> GetQuestionsRandomByNumberOfQuestions(int numberOfQuestions)
        {
            return await _quizRepository.GetQuestionsRandomByNumberOfQuestions(numberOfQuestions);
        }
        public async Task<bool> SaveQuizResponseAsync(QuizResponseModel quizResponseModel)
        {
            return await _quizRepository.SaveQuizResponseAsync(quizResponseModel);
        }
    }
}
