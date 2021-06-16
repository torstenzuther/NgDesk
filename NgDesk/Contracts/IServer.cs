using System;
using System.Threading.Tasks;

namespace NgDesk.Contracts
{
    public interface IServer : IDisposable
    {
        Task ServeAsync(string uri);

        void Stop();
    }
}