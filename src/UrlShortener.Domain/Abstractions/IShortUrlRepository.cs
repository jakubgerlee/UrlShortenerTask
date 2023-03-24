using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Domain.Abstractions
{
    public interface IShortUrlRepository
    {
        Task CreateShortUrlAsync(ShortUrl shortUrl);
        Task<ShortUrl> GetShortUrlAsync(string shortCode);
        Task<IEnumerable<ShortUrl>> GetAllShortUrlsAsync();
        bool ShortUrlExists(string shortCode);
    }
}
