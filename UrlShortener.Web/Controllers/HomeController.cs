using Microsoft.AspNetCore.Mvc;
using UrlShortener.Application.Interfaces;
using UrlShortener.Web.Models;

namespace UrlShortener.Web.Controllers
{
    public class HomeController(IUrlShortenerService urlShortenerService, IConfiguration configuration) : Controller
    {
        private readonly IUrlShortenerService _urlShortenerService = urlShortenerService;
        private readonly IConfiguration _configuration = configuration;
        public async Task<IActionResult> Index()
        {
            var urls = await _urlShortenerService.GetAllUrlsAsync();
            return View(urls);
        }

        [HttpPost]
        public async Task<IActionResult> Shorten(ShortenUrlViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var urls = await _urlShortenerService.GetAllUrlsAsync();
                return View("Index", urls);
            }

            try
            {
                var shortCode = await _urlShortenerService.CreateShortUrlAsync(model.OriginalUrl);
                var shortUrl = $"{_configuration["BaseUrl"]}/{shortCode}";
                ViewBag.ShortUrl = shortUrl;
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("OriginalUrl", ex.Message);
            }

            var allUrls = await _urlShortenerService.GetAllUrlsAsync();
            return View("Index", allUrls);
        }

        [HttpGet("{shortCode}")]
        public async Task<IActionResult> RedirectToOriginal(string shortCode)
        {
            var originalUrl = await _urlShortenerService.GetOriginalUrlAsync(shortCode);
            if (originalUrl == null)
            {
                return NotFound();
            }

            await _urlShortenerService.IncrementClickCountAsync(shortCode);
            return Redirect(originalUrl);
        }
    }
}