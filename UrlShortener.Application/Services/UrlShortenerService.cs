using UrlShortener.Application.DTOs;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Services
{
    public class UrlShortenerService(IUrlShortenerRepository repository) : IUrlShortenerService
    {
        private readonly IUrlShortenerRepository _repository = repository;
        private const string Base62Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private readonly Random _random = new();
        public async Task<string> CreateShortUrlAsync(string originalUrl)
        {
            if (!Uri.TryCreate(originalUrl, UriKind.Absolute, out var uriResult) ||
                (uriResult.Scheme != Uri.UriSchemeHttp && uriResult.Scheme != Uri.UriSchemeHttps))
            {
                throw new ArgumentException("Invalid URL format.");
            }

            var existingUrl = await _repository.GetByOriginalUrlAsync(originalUrl);
            if (existingUrl != null)
            {
                return existingUrl.ShortCode;
            }

            var shortCode = GenerateShortCode();
            var shortUrl = new ShortUrl
            {
                Id = Guid.NewGuid().ToString(),
                OriginalUrl = originalUrl,
                ShortCode = shortCode,
                CreatedAt = DateTime.UtcNow,
                ClickCount = 0
            };

            await _repository.AddAsync(shortUrl);
            return shortCode;
        }
        public async Task<string?> GetOriginalUrlAsync(string shortCode)
        {
            var shortUrl = await _repository.GetByShortCodeAsync(shortCode);
            return shortUrl?.OriginalUrl;
        }
        public async Task IncrementClickCountAsync(string shortCode)
        {
            var shortUrl = await _repository.GetByShortCodeAsync(shortCode);
            if (shortUrl != null)
            {
                shortUrl.ClickCount++;
                await _repository.UpdateAsync(shortUrl);
            }
        }
        public async Task<List<ShortUrlDto>> GetAllUrlsAsync()
        {
            var urls = await _repository.GetAllAsync();
            return urls.Select(u => new ShortUrlDto
            {
                Id = u.Id,
                OriginalUrl = u.OriginalUrl,
                ShortCode = u.ShortCode,
                CreatedAt = u.CreatedAt,
                ClickCount = u.ClickCount
            }).ToList();
        }
        private string GenerateShortCode()
        {
            var code = new char[7];
            for (int i = 0; i < 7; i++)
            {
                code[i] = Base62Chars[_random.Next(Base62Chars.Length)];
            }
            return new string(code);
        }
    }
}
