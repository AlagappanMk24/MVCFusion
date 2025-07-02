using Microsoft.AspNetCore.Mvc;
using RedisCache.Application.Interfaces;
using RedisCache.Web.Models;

namespace RedisCache.Web.Controllers
{
    public class HomeController(ICacheService cacheService) : Controller
    {
        private readonly ICacheService _cacheService = cacheService;

        public async Task<IActionResult> Index()
        {
            var entries = await _cacheService.GetAllAsync();
            return View(entries);
        }

        [HttpPost]
        public async Task<IActionResult> Store(CacheEntryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var entries = await _cacheService.GetAllAsync();
                return View("Index", entries);
            }

            try
            {
                await _cacheService.StoreAsync(model.Key, model.Value);
                ViewBag.SuccessMessage = $"Stored key '{model.Key}' successfully.";
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            var allEntries = await _cacheService.GetAllAsync();
            return View("Index", allEntries);
        }

        [HttpPost]
        public async Task<IActionResult> Retrieve(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                ModelState.AddModelError("", "Key is required.");
                var entries = await _cacheService.GetAllAsync();
                return View("Index", entries);
            }

            try
            {
                var value = await _cacheService.GetAsync(key);
                if (value != null)
                {
                    ViewBag.SuccessMessage = $"Retrieved value: {value}";
                }
                else
                {
                    ViewBag.ErrorMessage = $"Key '{key}' not found.";
                }
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            var allEntries = await _cacheService.GetAllAsync();
            return View("Index", allEntries);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                ModelState.AddModelError("", "Key is required.");
                var entries = await _cacheService.GetAllAsync();
                return View("Index", entries);
            }

            try
            {
                await _cacheService.DeleteAsync(key);
                ViewBag.SuccessMessage = $"Deleted key '{key}' successfully.";
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            var allEntries = await _cacheService.GetAllAsync();
            return View("Index", allEntries);
        }
    }
}