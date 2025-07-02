using UrlShortener.Application.DTOs;

namespace UrlShortener.Application.Interfaces
{
    public interface IUrlShortenerService
    {
        Task<string> CreateShortUrlAsync(string originalUrl);
        Task<string?> GetOriginalUrlAsync(string shortCode);
        Task IncrementClickCountAsync(string shortCode);
        Task<List<ShortUrlDto>> GetAllUrlsAsync();
    }
}