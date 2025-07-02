using RedisCache.Domain.Entities;

namespace RedisCache.Application.Interfaces
{
    public interface ICacheRepository
    {
        Task<CacheEntry?> GetByKeyAsync(string key);
        Task<List<CacheEntry>> GetAllAsync();
        Task AddAsync(CacheEntry entry);
        Task UpdateAsync(CacheEntry entry);
        Task DeleteAsync(string key);
    }
}
