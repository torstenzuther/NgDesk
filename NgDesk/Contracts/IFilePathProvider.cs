using System.Collections.Generic;

namespace NgDesk.Contracts
{
    public interface IFilePathProvider
    {
        public IEnumerable<FilePath> GetFiles(FilePath path);
    }
}