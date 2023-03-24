using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain;

namespace UrlShortener.Data.DbContext;

public class UrlShortenerContext : Microsoft.EntityFrameworkCore.DbContext
{
    public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options)
        : base(options)
    {
    }

    public DbSet<ShortUrl> ShortUrls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // I can add existing links
    }
}