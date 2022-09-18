using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NgDesk.Contracts;

namespace NgDesk.Implementation;

public class ResourceFilePathProvider : IFilePathProvider
{
    private readonly Assembly _assembly;

    public ResourceFilePathProvider(Assembly assembly)
    {
        _assembly = assembly;
    }
    public IEnumerable<FilePath> GetFiles(FilePath root)
    {
        return _assembly
            .GetManifestResourceNames()
            .Where(resourceName => resourceName.StartsWith(root))
            .Select(resourceName => Trim(resourceName, root));
    }

    private static FilePath Trim(string resourceName, FilePath prefix)
    {
        resourceName = resourceName.Replace(prefix, "");
        return resourceName.StartsWith(Path.DirectorySeparatorChar)
            ? resourceName[1..]
            : resourceName;
    }
}