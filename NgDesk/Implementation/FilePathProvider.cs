using System.Collections.Generic;
using System.IO;
using System.Linq;
using NgDesk.Contracts;

namespace NgDesk.Implementation;

public class FilePathProvider : IFilePathProvider
{
    public IEnumerable<FilePath> GetFiles(FilePath path)
    {
        var files = Directory.GetFiles(path, "*", new EnumerationOptions
        {
            RecurseSubdirectories = true,
            ReturnSpecialDirectories = false
        });

        var relativeFilePaths = files
            .Select(file => new FilePath(Path.GetRelativePath(path, file)));
            
        return relativeFilePaths;
    }
}