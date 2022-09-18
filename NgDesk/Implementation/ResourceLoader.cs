using System.IO;
using System.Reflection;
using NgDesk.Contracts;

namespace NgDesk.Implementation;

public class ResourceLoader: IBinaryLoader<FilePath>
{
    private readonly Assembly _assembly;

    public ResourceLoader(Assembly assembly)
    {
        _assembly = assembly;
    }
        
    public byte[] Load(FilePath manifestName)
    {
        var stream = _assembly
            .GetManifestResourceStream(manifestName);
        using var reader = new BinaryReader(stream!);
        return reader.ReadBytes((int)stream.Length);
    }
}