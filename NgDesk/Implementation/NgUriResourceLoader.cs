using System.Collections.Generic;
using System.Reflection;
using NgDesk.Contracts;

namespace NgDesk.Implementation
{
    public class NgUriResourceLoader: IUriResourceLoader
    {
        private readonly IUriResourceLoader _uriResourceLoader;

        public NgUriResourceLoader(string defaultPath, IRootPathProvider rootPathProvider, Assembly assembly)
        {
            var root = rootPathProvider.GetRoot();
            var filePathProvider = new ResourceFilePathProvider(assembly);
            var files = filePathProvider.GetFiles(root);
            
            _uriResourceLoader = new CachedUriResourceLoader(
                new MappedUriResourcePathLoader(
                    new ResourceLoader(assembly),
                    root,
                    new SpaPathMapper(
                        defaultPath,
                        new HashSet<FilePath>(files)),
                    new PathCombinator()));
        }

        public byte[] Load(UriPath path)
        {
            return _uriResourceLoader.Load(path);
        }
    }
}