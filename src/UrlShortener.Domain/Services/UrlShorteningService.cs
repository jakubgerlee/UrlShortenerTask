using UrlShortener.Domain.Abstractions;

namespace UrlShortener.Domain.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        private readonly IShortUrlRepository _shortUrlRepository;
        private const string UrlCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private static readonly Random Random = new();

        public UrlShorteningService(IShortUrlRepository shortUrlRepository)
        {
            _shortUrlRepository = shortUrlRepository;
        }

        public async Task<ShortUrl> CreateShortUrlAsync(string originalUrl)
        {
            var shortCode = GenerateShortCode(6);
            var shortUrl = new ShortUrl
            {
                OriginalUrl = originalUrl,
                ShortenedUrl = shortCode,
                DateCreated = DateTime.UtcNow
            };

            await _shortUrlRepository.CreateShortUrlAsync(shortUrl);
            return shortUrl;
        }

        public async Task<ShortUrl> GetShortUrlAsync(string shortCode)
        {
            return await _shortUrlRepository.GetShortUrlAsync(shortCode);
        }

        public async Task<IEnumerable<ShortUrl>> GetAllShortUrlsAsync()
        {
            return await _shortUrlRepository.GetAllShortUrlsAsync();
        }

        private string GenerateShortCode(int length)
        {
            string shortCode;
            do
            {
                shortCode = new string(Enumerable.Repeat(UrlCharacters, length)
                    .Select(s => s[Random.Next(s.Length)]).ToArray());

            } while (_shortUrlRepository.ShortUrlExists(shortCode));

            return shortCode;
        }
    }
}