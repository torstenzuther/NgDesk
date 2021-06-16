using System.IO;
using System.Reflection;
using FluentAssertions;
using NgDesk.Implementation;
using Xunit;

namespace NgDesk.Test
{
    public class ResourceLoaderTests
    {
        private readonly ResourceLoader _resourceLoader;

        public ResourceLoaderTests()
        {
            _resourceLoader = new ResourceLoader(Assembly.GetExecutingAssembly());
        }
        
        [Theory]
        [InlineData("..", TestConstants.TestFolder, "test.txt")]
        [InlineData("..", TestConstants.TestFolder, TestConstants.TestSubFolder, "test.txt")]
        public void ResourceLoader_Load_Should_Return_Embedded_Resources(params string[] resourceNameSegments)
        {
            var resourceName = string.Join(Path.DirectorySeparatorChar, resourceNameSegments);

            var byteContent = _resourceLoader.Load(resourceName);

            byteContent.Should().NotBeNull();
            byteContent.Should().NotBeEmpty();
        }
    }
}