using FluentAssertions;
using NgDesk.Contracts;
using NgDesk.Implementation;
using NSubstitute;
using Xunit;

namespace NgDesk.Test;

public class CachedUriResourceLoaderTests
{
    private readonly IUriResourceLoader _uriResourceLoader;
    private readonly CachedUriResourceLoader _cachedUriResourceLoader;

    public CachedUriResourceLoaderTests()
    {
        _uriResourceLoader = Substitute.For<IUriResourceLoader>();
        _cachedUriResourceLoader = new CachedUriResourceLoader(_uriResourceLoader);
    }

    [Fact]
    public void CachedUriResourceLoader_Load_Should_Return_Content()
    {
        var uriPath = "/testPath";
        var expectedContent = new byte[] {1, 1, 2, 3, 5, 8, 13, 21, 34};
        _uriResourceLoader.Load(uriPath)
            .Returns(expectedContent);

        var actualContent = _cachedUriResourceLoader.Load(uriPath);

        actualContent.Should().BeEquivalentTo(expectedContent);
        _uriResourceLoader.Received(1).Load(uriPath);
    }
        
    [Fact]
    public void CachedUriResourceLoader_Load_Should_Call_Underlying_UriResourceLoader_Only_Once()
    {
        var uriPath = "/testPath";
        var expectedContent = new byte[] {1, 1, 2, 3, 5, 8, 13, 21, 34};
        _uriResourceLoader.Load(uriPath)
            .Returns(expectedContent);

        _cachedUriResourceLoader.Load(uriPath);
        _cachedUriResourceLoader.Load(uriPath);

        _uriResourceLoader.Received(1).Load(uriPath);
    }
}