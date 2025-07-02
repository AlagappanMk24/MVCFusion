using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Web.Models
{
    public class ShortenUrlViewModel
    {
        [Required(ErrorMessage = "URL is required")]
        [Url(ErrorMessage = "Invalid URL format")]
        public string OriginalUrl { get; set; } = string.Empty;
    }
}
