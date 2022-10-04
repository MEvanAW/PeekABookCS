using System.Text.Json.Serialization;

namespace PeekABookWebApp.Models
{
    public class Item
    {
        [JsonPropertyName("volumeInfo")]
        public Book? Book { get; set; }
    }
}
