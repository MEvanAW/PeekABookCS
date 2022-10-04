namespace PeekABookWebApp.Models
{
    public class ImageLinks
    {
        public string? SmallThumbnail { get; set; }
        public string? Thumbnail { get; set; }
        public string? Small { get; set; }
        public string? Medium { get; set; }
        public string? Large { get; set; }
        public string? ExtraLarge { get; set; }

        public string Src()
        {
            if (ExtraLarge != null)
                return ExtraLarge;
            if (Large != null)
                return Large;
            if (Medium != null)
                return Medium;
            if (Small != null)
                return Small;
            if (Thumbnail != null)
                return Thumbnail;
            if (SmallThumbnail != null)
                return SmallThumbnail;
            return "";
        }
    }
}
