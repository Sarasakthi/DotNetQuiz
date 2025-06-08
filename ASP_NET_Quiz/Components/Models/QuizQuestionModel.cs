namespace ASP_NET_Quiz.Components.Models
{

    public class QuizQuestionModel
    {
        public int questionNumber { get; set; }
        public required string question { get; set; }
        public required List<string> options { get; set; }
        public int correctResponse { get; set; }
        public required string explanation { get; set; }
    }
}
