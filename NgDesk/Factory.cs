using System.Reflection;
using NgDesk.Contracts;
using NgDesk.Implementation;

namespace NgDesk
{
    public static class Factory
    {
        public static IServer GetServerUsingFilePath(string defaultRoute = "index.html")
        {
            var assembly = Assembly.GetCallingAssembly();
            return new HttpListener(
                new NgFileSystemLoader(
                    defaultRoute,
                    new RootPathProvider(assembly)));
        }
        
        public static IServer GetServerUsingEmbeddedResources(string defaultRoute = "index.html")
        {
            var assembly = Assembly.GetCallingAssembly();
            return new HttpListener(
                new NgUriResourceLoader(
                    defaultRoute,
                    new RootPathProvider(assembly), assembly));
        }
    }
}