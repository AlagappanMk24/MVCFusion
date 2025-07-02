using RedisCache.Application.DTOs;

namespace RedisCache.Application.Interfaces
{
    public interface ICacheService
    {
        Task StoreAsync(string key, string value, TimeSpan? expiry = null);
        Task<string?> GetAsync(string key);
        Task DeleteAsync(string key);
        Task<List<CacheEntryDto>> GetAllAsync();
    }
}
