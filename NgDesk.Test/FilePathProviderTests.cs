using System.IO;
using System.Linq;
using System.Text;
using FluentAssertions;
using NgDesk.Contracts;
using NgDesk.Implementation;
using Xunit;

namespace NgDesk.Test;

public class FilePathProviderTests
{
    private readonly FilePathProvider _filePathProvider;

    public FilePathProviderTests()
    {
        _filePathProvider = new FilePathProvider();
    }

    [Theory]
    [InlineData("..", "..", "..", "..", TestConstants.TestFolder)]
    public void FileLoader_Load_Should_Return_File_Content(params string[] pathSegments)
    {
        var expected = new[]
        {
            "test.txt",
            $"{TestConstants.TestSubFolder}{Path.DirectorySeparatorChar}test.txt"
        }.OrderBy(file => file);
        var filePath = string.Join(Path.DirectorySeparatorChar, pathSegments);

        var files = _filePathProvider.GetFiles(filePath)
            .Select(file => (string)file)
            .OrderBy(file => file)
            .ToList();

        files.Should().BeEquivalentTo(expected);
    }
}