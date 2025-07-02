using Microsoft.EntityFrameworkCore;
using UrlShortener.Application.Interfaces;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Data.Context;

namespace UrlShortener.Infrastructure.Repositories
{
    public class UrlShortenerRepository(ApplicationDbContext context) : IUrlShortenerRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<ShortUrl?> GetByShortCodeAsync(string shortCode)
        {
            return await _context.ShortUrls
                .FirstOrDefaultAsync(s => s.ShortCode == shortCode);
        }
        public async Task<ShortUrl?> GetByOriginalUrlAsync(string originalUrl)
        {
            return await _context.ShortUrls
                .FirstOrDefaultAsync(s => s.OriginalUrl == originalUrl);
        }
        public async Task<List<ShortUrl>> GetAllAsync()
        {
            return await _context.ShortUrls
                .ToListAsync();
        }
        public async Task AddAsync(ShortUrl shortUrl)
        {
            await _context.ShortUrls.AddAsync(shortUrl);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ShortUrl shortUrl)
        {
            _context.ShortUrls.Update(shortUrl);
            await _context.SaveChangesAsync();
        }
    }
}
