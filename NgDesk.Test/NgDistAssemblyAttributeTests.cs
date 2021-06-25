using System.IO;
using System.Reflection;
using FluentAssertions;
using NgDesk.Implementation;
using Xunit;

namespace NgDesk.Test
{
    public class NgDistAssemblyAttributeTests
    {
        [Fact]
        public void Executing_Assembly_Should_Contain_Custom_Assembly_Attribute()
        {
            var attribute = Assembly
                .GetExecutingAssembly()
                .GetCustomAttribute<NgDeskAttribute>();

            attribute.Should().NotBeNull();
            attribute!.Path.Should().Be($"..{Path.DirectorySeparatorChar}{TestConstants.TestFolder}");
        }
    }
}