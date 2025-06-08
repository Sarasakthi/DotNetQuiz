namespace ASP_NET_Quiz.Components.Models
{
    public class FirestoreResponseModel
    {
        public List<Document>? documents { get; set; }
    }

    public class Document
    {
        public Dictionary<string, FirestoreField>? fields { get; set; }
    }

    public class FirestoreField
    {
        public string? stringValue { get; set; }
        public string? integerValue { get; set; }
        public FirestoreArray? arrayValue { get; set; }
    }

    public class FirestoreArray
    {
        public List<FirestoreField>? values { get; set; }
    }
}
