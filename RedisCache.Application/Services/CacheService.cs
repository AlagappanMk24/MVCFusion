using RedisCache.Application.DTOs;
using RedisCache.Application.Interfaces;
using RedisCache.Domain.Entities;
using StackExchange.Redis;

namespace RedisCache.Application.Services
{
    public class CacheService : ICacheService
    {
        private readonly ICacheRepository _repository;
        private readonly IDatabase _redisDb;
        public CacheService(ICacheRepository repository, IConnectionMultiplexer redis)
        {
            _repository = repository;
            _redisDb = redis.GetDatabase();
        }
        public async Task StoreAsync(string key, string value, TimeSpan? expiry = null)
        {
            if (string.IsNullOrWhiteSpace(key) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Key and value cannot be empty.");
            }

            await _redisDb.StringSetAsync(key, value, expiry ?? TimeSpan.FromHours(1));

            var entry = await _repository.GetByKeyAsync(key);
            if (entry == null)
            {
                entry = new CacheEntry
                {
                    Id = Guid.NewGuid().ToString(),
                    Key = key,
                    Value = value,
                    CreatedAt = DateTime.UtcNow,
                    HitCount = 0
                };
                await _repository.AddAsync(entry);
            }
            else
            {
                entry.Value = value;
                await _repository.UpdateAsync(entry);
            }
        }

        public async Task<string?> GetAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be empty.");
            }

            var value = await _redisDb.StringGetAsync(key);
            if (value.HasValue)
            {
                var entry = await _repository.GetByKeyAsync(key);
                if (entry != null)
                {
                    entry.HitCount++;
                    await _repository.UpdateAsync(entry);
                }
                return value.ToString();
            }
            return null;
        }

        public async Task DeleteAsync(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be empty.");
            }

            await _redisDb.KeyDeleteAsync(key);
            await _repository.DeleteAsync(key);
        }

        public async Task<List<CacheEntryDto>> GetAllAsync()
        {
            var entries = await _repository.GetAllAsync();
            return entries.Select(e => new CacheEntryDto
            {
                Id = e.Id,
                Key = e.Key,
                Value = e.Value,
                CreatedAt = e.CreatedAt,
                HitCount = e.HitCount
            }).ToList();
        }
    }
}
