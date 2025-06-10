using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Quiz.Components.Models
{
    public class QuizResponseModel
    {
        [Key]
        public int QuestionNumber { get; set; }
        public string UserResponse { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
    }
}
