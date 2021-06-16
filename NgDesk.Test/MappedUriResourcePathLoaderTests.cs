using FluentAssertions;
using NgDesk.Contracts;
using NgDesk.Implementation;
using NSubstitute;
using Xunit;

namespace NgDesk.Test
{
    public class MappedUriResourcePathLoaderTests
    {
        private readonly IBinaryLoader<FilePath> _binaryLoader;
        private readonly FilePath _rootPath;
        private readonly IPathMapper _pathMapper;
        private readonly IPathCombinator _pathCombinator;
        private readonly MappedUriResourcePathLoader _mappedUriResourcePathLoader;

        public MappedUriResourcePathLoaderTests()
        {
            _binaryLoader = Substitute.For<IBinaryLoader<FilePath>>();
            _rootPath = "abc";
            _pathMapper = Substitute.For<IPathMapper>();
            _pathCombinator = Substitute.For<IPathCombinator>();
            _mappedUriResourcePathLoader = new MappedUriResourcePathLoader(
                _binaryLoader,
                _rootPath,
                _pathMapper,
                _pathCombinator);
        }

        [Fact]
        public void MappedUriResourcePathLoader_Load_Should_Return_Content()
        {
            UriPath uriPath = "TestPath/123";
            FilePath mappedFilePath = "abc/123/345";
            FilePath combinedPath = "1lasdlka7a/asd";
            var expected = new byte[] {1, 1, 2, 3, 5, 8, 13, 21, 34};
            _pathMapper.Map(uriPath).Returns(mappedFilePath);
            _pathCombinator.Combine(_rootPath, mappedFilePath).Returns(combinedPath);
            _binaryLoader.Load(combinedPath).Returns(expected);

            var actual = _mappedUriResourcePathLoader.Load(uriPath);

            actual.Should().BeEquivalentTo(expected);
        }
        
    }
}