using System;
using System.Threading.Tasks;

namespace NgDesk.Contracts;

/// <summary>
/// The server contract.
/// </summary>
public interface IServer : IDisposable
{
    /// <summary>
    /// Serves the file content specified in .csproj under the given URI, e.g. http://localhost:4444
    /// </summary>
    Task ServeAsync(string uri);

    /// <summary>
    /// Stops the server. Should be called on application shutdown.
    /// </summary>
    void Stop();
}