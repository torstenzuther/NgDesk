using System.IO;
using NgDesk.Contracts;

namespace NgDesk.Implementation
{
    public class PathCombinator : IPathCombinator
    {
        public FilePath Combine(FilePath root, FilePath path)
        {
            return Path.Combine(root, path);
        }
    }
}