using NgDesk.Contracts;

namespace NgDesk.Implementation;

public class MappedUriResourcePathLoader: IUriResourceLoader
{
    private readonly IBinaryLoader<FilePath> _binaryLoader;
    private readonly FilePath _rootPath;
    private readonly IPathMapper _pathMapper;
    private readonly IPathCombinator _pathCombinator;

    public MappedUriResourcePathLoader(
        IBinaryLoader<FilePath> binaryLoader,
        FilePath rootPath,
        IPathMapper pathMapper,
        IPathCombinator pathCombinator)
    {
        _binaryLoader = binaryLoader;
        _rootPath = rootPath;
        _pathMapper = pathMapper;
        _pathCombinator = pathCombinator;
    }

    public byte[] Load(UriPath path)
    {
        var mapped = _pathMapper.Map(path);
        var combined = _pathCombinator.Combine(_rootPath, mapped);
        return _binaryLoader.Load(combined);
    }
}