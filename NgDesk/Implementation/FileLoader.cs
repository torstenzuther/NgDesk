using System.IO;
using NgDesk.Contracts;

namespace NgDesk.Implementation;

public class FileLoader: IBinaryLoader<FilePath>
{
    public byte[] Load(FilePath path)
    {
        return File.ReadAllBytes(path);
    }
}