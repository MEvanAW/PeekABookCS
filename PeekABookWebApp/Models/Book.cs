namespace PeekABookWebApp.Models
{
    public class Book
    {
        public string Title { get; set; } = "No Title";
        public IEnumerable<string> Authors { get; set; } = new List<string> {"Anonym"};
        public string? Description { get; set; }
        public int? PageCount { get; set; }
        public IEnumerable<string>? Categories { get; set; }
        public double? AverageRating { get; set; }
        public ImageLinks ImageLinks { get; set; } = new ImageLinks();
        public string? PreviewLink { get; set; }
    }
}
