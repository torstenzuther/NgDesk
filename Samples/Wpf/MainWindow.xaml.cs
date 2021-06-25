using System;
using Microsoft.Web.WebView2.Core;

namespace Wpf
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            WebView.WebMessageReceived += WebMessageReceived;
            WebView.CoreWebView2InitializationCompleted += WebViewOnCoreWebView2InitializationCompleted;
            await WebView.EnsureCoreWebView2Async();
        }

        private void WebViewOnCoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            WebView.CoreWebView2.OpenDevToolsWindow();
        }

        private void WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            Console.WriteLine(e.WebMessageAsJson);
            WebView.CoreWebView2.PostWebMessageAsString(e.WebMessageAsJson);
        }
    }
}