using System.Collections.Generic;
using NgDesk.Contracts;

namespace NgDesk.Implementation;

public class SpaPathMapper : IPathMapper
{
    private readonly string _defaultPath;
    private readonly HashSet<FilePath> _files;

    public SpaPathMapper(string defaultPath, HashSet<FilePath> files)
    {
        _defaultPath = defaultPath;
        _files = files;
    }
        
    public FilePath Map(FilePath path)
    {
        return !_files.Contains(path)
            ? _defaultPath
            : path;
    }
}