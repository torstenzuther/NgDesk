using System.IO;
using System.Reflection;
using FluentAssertions;
using Xunit;

namespace NgDesk.Test
{
    public class EmbeddedResourceTests
    {
        private readonly Assembly _assembly;

        public EmbeddedResourceTests()
        {
            _assembly = Assembly.GetExecutingAssembly();
        }
        
        [Fact]
        public void Executing_Assembly_Should_Have_Resources()
        {
            var resources = _assembly.GetManifestResourceNames();

            resources.Should().NotBeEmpty();
        }
        
        [Theory]
        [InlineData("..", TestConstants.TestFolder, "test.txt")]
        [InlineData("..", TestConstants.TestFolder, TestConstants.TestSubFolder, "test.txt")]
        public void Executing_Assembly_Should_Have_Embedded_Test_Resource_Files(params string[] pathSegments)
        {
            var path = string.Join(Path.DirectorySeparatorChar, pathSegments);
            
            var resources = _assembly.GetManifestResourceNames();

            resources.Should().Contain(path);
        }
        
        [Theory]
        [InlineData(nameof(NgDesk), nameof(Test), "EmbeddedTestResource.resources")]
        [InlineData(nameof(NgDesk), nameof(Test), "EmbeddedTestResource2", "EmbeddedTestResource2.resources")]
        public void Executing_Assembly_Should_Have_Embedded_Test_Resx_Files(params string[] resourceNameSegments)
        {
            var resourceName = string.Join('.', resourceNameSegments);
            
            var resourceInfo = _assembly.GetManifestResourceInfo(resourceName);

            resourceInfo.Should().NotBeNull();
        }
    }
}