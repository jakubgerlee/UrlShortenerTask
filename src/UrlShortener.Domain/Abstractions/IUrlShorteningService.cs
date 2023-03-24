namespace UrlShortener.Domain.Abstractions;

public interface IUrlShorteningService
{
    Task<ShortUrl> CreateShortUrlAsync(string originalUrl);
    Task<ShortUrl> GetShortUrlAsync(string shortCode);
    Task<IEnumerable<ShortUrl>> GetAllShortUrlsAsync();
}