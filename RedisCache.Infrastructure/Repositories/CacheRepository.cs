using Microsoft.EntityFrameworkCore;
using RedisCache.Application.Interfaces;
using RedisCache.Domain.Entities;
using RedisCache.Infrastructure.Data.Context;

namespace RedisCache.Infrastructure.Repositories
{
    public class CacheRepository : ICacheRepository
    {
        private readonly ApplicationDbContext _context;

        public CacheRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CacheEntry?> GetByKeyAsync(string key)
        {
            return await _context.CacheEntries
                .FirstOrDefaultAsync(e => e.Key == key);
        }

        public async Task<List<CacheEntry>> GetAllAsync()
        {
            return await _context.CacheEntries
                .ToListAsync();
        }

        public async Task AddAsync(CacheEntry entry)
        {
            await _context.CacheEntries.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CacheEntry entry)
        {
            _context.CacheEntries.Update(entry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string key)
        {
            var entry = await GetByKeyAsync(key);
            if (entry != null)
            {
                _context.CacheEntries.Remove(entry);
                await _context.SaveChangesAsync();
            }
        }
    }
}
