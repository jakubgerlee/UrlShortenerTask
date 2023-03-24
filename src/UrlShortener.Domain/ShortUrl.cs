namespace UrlShortener.Domain
{
    public class ShortUrl
    {
        public Guid Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}