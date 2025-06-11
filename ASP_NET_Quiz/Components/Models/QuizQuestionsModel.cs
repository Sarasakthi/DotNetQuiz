using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ASP_NET_Quiz.Components.Models
{

    public class QuizQuestionsModel
    {
        [Key]
        public int QuestionNumber { get; set; }
        public required string Question { get; set; }
        public required string CorrectResponse { get; set; }
        public required string Explanation { get; set; }

        public List<QuizOptionsModel> Options { get; set; } = new();
    }
}
