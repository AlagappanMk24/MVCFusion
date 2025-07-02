namespace RedisCache.Domain.Entities
{
    public class CacheEntry
    {
        public string Id { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int HitCount { get; set; }
    }
}
