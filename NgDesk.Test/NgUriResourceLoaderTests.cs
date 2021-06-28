using System.Reflection;
using FluentAssertions;
using NgDesk.Contracts;
using NgDesk.Implementation;
using Xunit;

namespace NgDesk.Test
{
    public class NgUriResourceLoaderTests
    {
        private readonly NgUriResourceLoader _uriResourceLoader;

        public NgUriResourceLoaderTests()
        {
            _uriResourceLoader = new NgUriResourceLoader(
                "index.html",
                new RootPathProvider(Assembly.GetExecutingAssembly()),
                Assembly.GetExecutingAssembly());
        }

        [Theory]
        [InlineData("/test.txt")]
        [InlineData("/TestSubFolder/test.txt")]
        public void NgUriResourceLoader_Load_Should_Return_Embedded_Resources(string path)
        {
            var byteContent = _uriResourceLoader.Load(path);

            byteContent.Should().NotBeNull();
            byteContent.Should().NotBeEmpty();
        }
    }
}