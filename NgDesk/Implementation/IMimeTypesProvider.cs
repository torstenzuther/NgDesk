namespace NgDesk.Implementation;

public interface IMimeTypesProvider
{
    public string GetMimeTypeByRequestedResourcePath(string resourcePath);
}