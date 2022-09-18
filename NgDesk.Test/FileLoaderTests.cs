using System.IO;
using System.Text;
using FluentAssertions;
using NgDesk.Implementation;
using Xunit;

namespace NgDesk.Test;

public class FileLoaderTests
{
    private readonly FileLoader _fileLoader;

    public FileLoaderTests()
    {
        _fileLoader = new FileLoader();
    }

    [Theory]
    [InlineData("Test.txt", "..", "..", "..", "..", TestConstants.TestFolder, "test.txt")]
    [InlineData("Test.txt2", "..", "..", "..", "..", TestConstants.TestFolder, TestConstants.TestSubFolder, "test.txt")]
    public void FileLoader_Load_Should_Return_File_Content(string expectedContent, params string[] pathSegments)
    {
        var filePath = string.Join(Path.DirectorySeparatorChar, pathSegments);

        var byteContent = _fileLoader.Load(filePath);

        byteContent.Should().NotBeNull();
        byteContent.Should().BeEquivalentTo(Encoding.UTF8.GetBytes(expectedContent));
    }
}