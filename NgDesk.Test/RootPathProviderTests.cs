using System.IO;
using System.Reflection;
using FluentAssertions;
using NgDesk.Contracts;
using NgDesk.Implementation;
using Xunit;

namespace NgDesk.Test
{
    public class RootPathProviderTests
    {
        [Fact]
        public void RootPathProvider_Should_Return_RootPath_Configured_In_Csproj()
        {
            FilePath expected = $"..{Path.DirectorySeparatorChar}{TestConstants.TestFolder}";

            var rootPathProvider = new RootPathProvider(Assembly.GetExecutingAssembly());

            rootPathProvider.GetRoot().Should().Be(expected);
        }
    }
}