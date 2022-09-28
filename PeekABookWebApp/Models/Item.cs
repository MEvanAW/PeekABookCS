using System.Text.Json.Serialization;

namespace PeekABookWebApp.Models
{
    public class Item
    {
        [JsonPropertyName("volumeInfo")]
        Book? Book { get; set; }
    }
}
