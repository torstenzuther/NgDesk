using System;
using System.Net;
using System.Threading.Tasks;
using NgDesk.Contracts;

namespace NgDesk.Implementation
{
    public class HttpListener : IServer
    {
        private readonly IUriResourceLoader _uriResourceLoader;
        private System.Net.HttpListener _listener;
        
        public HttpListener(IUriResourceLoader uriResourceLoader)
        {
            _uriResourceLoader = uriResourceLoader;
        }

        public async Task ServeAsync(string uri)
        {
            if (_listener != null)
            {
                return;
            }
            if (!System.Net.HttpListener.IsSupported)
            {
                throw new NotSupportedException("HttpListener not supported.");
            }

            _listener = new System.Net.HttpListener();
            _listener.Prefixes.Add(uri);
            _listener.Start();
            while (true)
            {
                var context = await _listener.GetContextAsync();
                await Task.Factory.StartNew(() =>
                {
                    HandleRequest(context);
                });
            }
        }

        public void Stop()
        {
            _listener.Stop();
        }

        public void Dispose()
        {
            ((IDisposable) _listener)?.Dispose();
        }

        private void HandleRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;
            var buffer = _uriResourceLoader.Load(request.Url!.LocalPath);
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}