namespace ASP_NET_Quiz.Components.Service
{
    using System.Net.Http.Json;
    using ASP_NET_Quiz.Components.Models;

    public class QuizService
    {
        private readonly HttpClient _httpClient;
        private readonly string _projectId = "asp-net-quiz";
        private readonly string _apiKey = "AIzaSyC6JuU3gkyQAV4x3JjsbhviGoJBYLu4imw";
        public QuizService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<QuizQuestionModel>> GetQuizQuestionsAsync()
        {
            string url = $"https://firestore.googleapis.com/v1/projects/{_projectId}/databases/(default)/documents/quiz?key={_apiKey}";

            var response = await _httpClient.GetFromJsonAsync<FirestoreResponseModel>(url);

            if (response == null || response.documents == null)
                return new List<QuizQuestionModel>();

            return response.documents.Select(doc =>
            {
                var fields = doc.fields;
                return new QuizQuestionModel
                {
                    questionNumber = int.Parse(doc.fields["questionNumber"].integerValue),
                    question = doc.fields["question"].stringValue,
                    options = doc.fields["options"].arrayValue.values.Select(v => v.stringValue).ToList(),
                    correctResponse = int.Parse(doc.fields["correctResponse"].integerValue),
                    explanation = doc.fields["explanation"].stringValue
                };
            }).ToList();
        }
    }
}
