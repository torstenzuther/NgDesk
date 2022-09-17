namespace NgDesk.Implementation;

public class MimeTypesProvider : IMimeTypesProvider
{
    public string GetMimeTypeByRequestedResourcePath(string resourcePath)
    {
        if (resourcePath.EndsWith(".js") || resourcePath.EndsWith(".mjs"))
        {
            return "text/javascript";
        }
        
        if (resourcePath.EndsWith(".css"))
        {
            return "text/css";
        }

        if (resourcePath.EndsWith(".html") || resourcePath.EndsWith(".htm"))
        {
            return "text/html";
        }

        return null;
    }
}