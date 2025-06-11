using System.ComponentModel.DataAnnotations;

namespace ASP_NET_Quiz.Components.Models
{
    public class QuizOptionsModel
    {
        [Key]
        public int OptionId { get; set; }
        public int QuestionNumber { get; set; }
        public required string OptionText { get; set; }
        public int OptionIndex { get; set; }
        public required QuizQuestionsModel Question { get; set; }
    }
}
