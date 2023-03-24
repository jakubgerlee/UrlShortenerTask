using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.DbContext;
using UrlShortener.Domain;
using UrlShortener.Domain.Abstractions;

namespace UrlShortener.Data.Repositories
{
    public class ShortUrlRepository : IShortUrlRepository
    {
        private readonly UrlShortenerContext _dbContext;

        public ShortUrlRepository(UrlShortenerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateShortUrlAsync(ShortUrl shortUrl)
        {
            await _dbContext.ShortUrls.AddAsync(shortUrl);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ShortUrl> GetShortUrlAsync(string shortCode)
        {
            return await _dbContext.ShortUrls.FirstOrDefaultAsync(s => s.ShortenedUrl == shortCode);
        }

        public async Task<IEnumerable<ShortUrl>> GetAllShortUrlsAsync()
        {
            return await _dbContext.ShortUrls.ToListAsync();
        }

        public bool ShortUrlExists(string shortCode)
        {
            return _dbContext.ShortUrls.Any(s => s.ShortenedUrl == shortCode);
        }
    }
}