using System;
using System.Text.Json.Serialization;

namespace QuotesRestAPI.Model
{
    public class QuoteModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("Author")]
        public string Author { get; set; }

        [JsonPropertyName("Quote")]
        public string Quote { get; set; }

        [JsonPropertyName("Category")]
        public string Category { get; set; }
    
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
    }

        
}
