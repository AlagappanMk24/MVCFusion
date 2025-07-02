namespace UrlShortener.Application.DTOs
{
    public class ShortUrlDto
    {
        public string Id { get; set; } = string.Empty;
        public string OriginalUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ClickCount { get; set; }
    }
}