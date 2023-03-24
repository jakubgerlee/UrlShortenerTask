using System.Threading.Tasks;
using Moq;
using UrlShortener.Domain.Abstractions;
using UrlShortener.Domain.Services;
using Xunit;

namespace UrlShortener.Domain.Tests
{
    public class UrlShorteningServiceTests
    {
        private readonly Mock<IShortUrlRepository> _shortUrlRepositoryMock;
        private readonly UrlShorteningService _urlShorteningService;

        public UrlShorteningServiceTests()
        {
            _shortUrlRepositoryMock = new Mock<IShortUrlRepository>();
            _urlShorteningService = new UrlShorteningService(_shortUrlRepositoryMock.Object);
        }

        [Fact]
        public async Task CreateShortUrlAsync_CreatesShortUrlSuccessfully()
        {
            // Arrange
            string originalUrl = "https://www.example.com";
            _shortUrlRepositoryMock.Setup(x => x.ShortUrlExists(It.IsAny<string>())).Returns(false);

            // Act
            var shortUrl = await _urlShorteningService.CreateShortUrlAsync(originalUrl);

            // Assert
            Assert.NotNull(shortUrl);
            Assert.Equal(originalUrl, shortUrl.OriginalUrl);
            _shortUrlRepositoryMock.Verify(x => x.CreateShortUrlAsync(It.IsAny<ShortUrl>()), Times.Once());
        }
    }
}
