using System.Reflection;
using NgDesk.Contracts;
using NgDesk.Implementation;

namespace NgDesk;

/// <summary>
/// Factory to create default server
/// </summary>
public static class Factory
{
    /// <summary>
    /// Returns a new <see cref="IServer"/> instance by serving content from file path specified in .csproj file.
    /// </summary>
    /// <param name="defaultRoute">The default route for any unknown request. Necessary to support SPA routing.</param>
    /// <returns>a new <see cref="IServer"/> instance</returns>
    public static IServer GetServerUsingFilePath(string defaultRoute = "index.html")
    {
        var assembly = Assembly.GetCallingAssembly();
        return new HttpListener(
            new NgFileSystemLoader(
                defaultRoute,
                new RootPathProvider(assembly)),
            new MimeTypesProvider());
    }

    /// <summary>
    /// Returns a new <see cref="IServer"/> instance by serving content from file path specified in .csproj file (embedded as resources).
    /// </summary>
    /// <param name="defaultRoute">The default route for any unknown request. Necessary to support SPA routing.</param>
    /// <returns>a new <see cref="IServer"/> instance</returns>
    public static IServer GetServerUsingEmbeddedResources(string defaultRoute = "index.html")
    {
        var assembly = Assembly.GetCallingAssembly();
        return new HttpListener(
            new NgUriResourceLoader(
                defaultRoute,
                new RootPathProvider(assembly), assembly),
            new MimeTypesProvider());
    }
}