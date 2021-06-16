using System.Collections.Concurrent;
using NgDesk.Contracts;

namespace NgDesk.Implementation
{
    public class CachedUriResourceLoader : IUriResourceLoader
    {
        private readonly IUriResourceLoader _loader;
        private readonly ConcurrentDictionary<UriPath, byte[]> _cache;
        
        public CachedUriResourceLoader(IUriResourceLoader loader)
        {
            _loader = loader;
            _cache = new ConcurrentDictionary<UriPath, byte[]>();
        }

        public byte[] Load(UriPath path)
        {
            if (_cache.ContainsKey(path))
            {
                return _cache[path];
            }

            var content = _loader.Load(path);
            _cache[path] = content;
            return content;
        }
    }
}