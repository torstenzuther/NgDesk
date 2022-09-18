using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace Winforms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        InitializeAsync();
    }

    async void InitializeAsync()
    {
        webView.WebMessageReceived += WebMessageReceived;
        webView.CoreWebView2InitializationCompleted += WebView_CoreWebView2InitializationCompleted; ;
        await webView.EnsureCoreWebView2Async();
    }

    private void WebView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        webView.CoreWebView2.OpenDevToolsWindow();
    }

    private void WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
    {
        webView.CoreWebView2.PostWebMessageAsString(e.WebMessageAsJson);
    }
}