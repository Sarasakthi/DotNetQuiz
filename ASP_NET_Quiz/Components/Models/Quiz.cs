namespace ASP_NET_Quiz.Components.Models
{
    public class Quiz
    {
        public int QuestionNo { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string SelectedResponse { get; set; }
        public string CorrectResponse { get; set; }
        public string Explaination { get; set; }
    }
}
