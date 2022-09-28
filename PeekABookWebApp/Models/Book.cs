namespace PeekABookWebApp.Models
{
    public class Book
    {
        string Title { get; set; } = "No Title";
        IEnumerable<string> Authors { get; set; } = new List<string> {"Anonym"};
        string? Description { get; set; }
        int? PageCount { get; set; }
        IEnumerable<string>? Categories { get; set; }
        double? AverageRating { get; set; }
        ImageLinks? ImageLinks { get; set; }
        string? PreviewLink { get; set; }
    }
}
