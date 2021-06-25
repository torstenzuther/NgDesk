using System.Reflection;
using NgDesk.Contracts;

namespace NgDesk.Implementation
{
    public class RootPathProvider: IRootPathProvider
    {
        private readonly Assembly _assembly;

        public RootPathProvider(Assembly assembly)
        {
            _assembly = assembly;
        }
        
        public FilePath GetRoot()
        {
            return _assembly
                .GetCustomAttribute<NgDeskAttribute>()
                ?.Path;
        }
    }
}