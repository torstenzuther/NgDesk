using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var server = NgDesk.Factory.GetServerUsingFilePath();
        Task.Factory.StartNew(
            async () => await server.ServeAsync("http://localhost:4444/"));

        Application.Run(new MainForm());
    }
}