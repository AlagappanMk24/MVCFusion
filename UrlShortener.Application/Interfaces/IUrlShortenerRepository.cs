using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Interfaces
{
    public interface IUrlShortenerRepository
    {
        Task<ShortUrl?> GetByShortCodeAsync(string shortCode);
        Task<ShortUrl?> GetByOriginalUrlAsync(string originalUrl);
        Task<List<ShortUrl>> GetAllAsync();
        Task AddAsync(ShortUrl shortUrl);
        Task UpdateAsync(ShortUrl shortUrl);
    }
}
