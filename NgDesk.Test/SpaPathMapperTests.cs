using System.Linq;
using FluentAssertions;
using NgDesk.Contracts;
using NgDesk.Implementation;
using Xunit;

namespace NgDesk.Test
{
    public class SpaPathMapperTests
    {
        [Theory]
        [InlineData("askdj/dsa", "askdj/dsa", "random123")]
        [InlineData("askdj/dsa", "askdj/dsa", "random123", "test1", "test2")]
        [InlineData("askdj/dsa", "test123", "test123", "test123", "test2")]
        [InlineData("askdj/dsa", "askdj/dsa", "askdj/dsa", "test123", "test2")]
        [InlineData("askdj/dsa", "askdj/dsa", "askdj/dsa")]
        public void SpaPathMapper_Should_Return_Path(string @default, string expected, string requested, params string[] files)
        {
            FilePath expectedPath = expected;
            var spaPathMapper = new SpaPathMapper(
                @default,
                files.Select(file => new FilePath(file))
                    .ToHashSet());
            
            var actual = spaPathMapper.Map(requested);

            actual.Should().Be(expectedPath);
        }
    }
}