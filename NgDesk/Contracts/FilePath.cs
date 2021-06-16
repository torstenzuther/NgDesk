using System;
using System.IO;

namespace NgDesk.Contracts
{
    public readonly struct FilePath
    {
        private readonly string _path;

        public FilePath(string path)
        {
            _path = path;
        }

        public static implicit operator FilePath(string path)
        {
            return new(path);
        }
        
        public static implicit operator String(FilePath path)
        {
            return path._path;
        }

        public static implicit operator FilePath(UriPath path)
        {
            string pathAsString = path;
            if (pathAsString.StartsWith('/'))
            {
                pathAsString = pathAsString.Substring(1);
            }
            var uriPath = pathAsString
                .Replace('/', Path.DirectorySeparatorChar);

            return new FilePath(uriPath);
        }
    }
}