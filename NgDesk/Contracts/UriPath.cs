using System;

namespace NgDesk.Contracts;

public readonly struct UriPath
{
    private readonly string _path;

    private UriPath(string path)
    {
        _path = path;
    }

    public static implicit operator UriPath(string path)
    {
        return new(path);
    }
        
    public static implicit operator String(UriPath path)
    {
        return path._path;
    }
}