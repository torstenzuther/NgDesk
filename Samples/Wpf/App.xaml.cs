using System.Threading.Tasks;
using System.Windows;
using NgDesk;

namespace Wpf;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var server = NgDesk.Factory.GetServerUsingFilePath();
        Task.Factory.StartNew(
            async() => await server.ServeAsync("http://localhost:4444/"));
    }
}