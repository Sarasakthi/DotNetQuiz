using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Quiz.Components.Models
{
    public class QuizResponseModel
    {
        [Key]
        public int ResponseId { get; set; }
        public int QuestionNumber { get; set; }
        public required string UserResponse { get; set; }
        public bool IsCorrect { get; set; }
    }
}
