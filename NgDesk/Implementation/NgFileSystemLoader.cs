using System.Collections.Generic;
using NgDesk.Contracts;

namespace NgDesk.Implementation;

public class NgFileSystemLoader : IUriResourceLoader
{
    private readonly IUriResourceLoader _uriResourceLoader;

    public NgFileSystemLoader(string defaultPath, IRootPathProvider rootPathProvider)
    {
        var root = rootPathProvider.GetRoot();
        var filePathProvider = new FilePathProvider();
        var files = filePathProvider.GetFiles(root);
            
        _uriResourceLoader = new CachedUriResourceLoader(
            new MappedUriResourcePathLoader(
                new FileLoader(),
                root,
                new SpaPathMapper(
                    defaultPath,
                    new HashSet<FilePath>(files)),
                new PathCombinator()));
    }

    public byte[] Load(UriPath path)
    {
        return _uriResourceLoader.Load(path);
    }
}