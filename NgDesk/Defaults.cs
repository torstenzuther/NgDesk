using System.Reflection;
using NgDesk.Contracts;
using NgDesk.Implementation;

namespace NgDesk
{
    public static class Defaults
    {
        public static IServer GetDefaultHttpListener(string defaultPath = "index.html")
        {
            var assembly = Assembly.GetCallingAssembly();
            return new HttpListener(
                new NgFileSystemLoader(
                    defaultPath,
                    new RootPathProvider(assembly)));
        }
        
        public static IServer GetResourceHttpListener(string defaultPath = "index.html")
        {
            var assembly = Assembly.GetCallingAssembly();
            return new HttpListener(
                new NgUriResourceLoader(
                    defaultPath,
                    new RootPathProvider(assembly), assembly));
        }
    }
}