using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UrlShortener.Domain.Abstractions;
using UrlShortener.WebApplication.Controllers;
using UrlShortener.WebApplication.Models;
using UrlShortener.WebApplication.ViewModels;

namespace UrlShortener.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUrlShorteningService _urlShorteningService;

        public HomeController(ILogger<HomeController> logger, IUrlShorteningService urlShorteningService)
        {
            _logger = logger;
            _urlShorteningService = urlShorteningService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TechTaskDetails()
        {
            return View("TechTaskDetails");
        }

        [HttpPost]
        public async Task<IActionResult> CreateShortUrl(string originalUrl)
        {
            var shortUrl = await _urlShorteningService.CreateShortUrlAsync(originalUrl);
            return RedirectToAction("ShortUrls");
        }

        public async Task<IActionResult> ShortUrls()
        {
            var shortUrls = await _urlShorteningService.GetAllShortUrlsAsync();
            var viewModel = new ShortUrlsViewModel { ShortUrls = shortUrls.ToList() };
            return View(viewModel);
        }

        [HttpGet("r/{shortCode}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortCode)
        {
            var shortUrl = await _urlShorteningService.GetShortUrlAsync(shortCode);
            if (shortUrl == null)
            {
                return NotFound();
            }

            return Redirect(shortUrl.OriginalUrl);
        }
    }
}



