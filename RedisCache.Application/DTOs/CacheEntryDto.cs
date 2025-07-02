namespace RedisCache.Application.DTOs
{
    public class CacheEntryDto
    {
        public string Id { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int HitCount { get; set; }
    }
}
