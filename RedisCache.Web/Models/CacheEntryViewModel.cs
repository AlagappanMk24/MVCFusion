using System.ComponentModel.DataAnnotations;

namespace RedisCache.Web.Models
{
    public class CacheEntryViewModel
    {
        [Required(ErrorMessage = "Key is required")]
        public string Key { get; set; } = string.Empty;

        [Required(ErrorMessage = "Value is required")]
        public string Value { get; set; } = string.Empty;
    }
}
