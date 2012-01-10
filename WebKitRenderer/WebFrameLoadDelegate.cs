using System;
using WebKit.Interop;

namespace WebKit
{
    internal class WebFrameLoadDelegate : IWebFrameLoadDelegate
    {
        public void didCancelClientRedirectForFrame(WebView webView, IWebFrame frame)
        {}

        public void didChangeLocationWithinPageForFrame(WebView webView, IWebFrame frame)
        {}

        public void didClearWindowObject(WebView webView, IntPtr context, IntPtr windowScriptObject, IWebFrame frame)
        {}

        public void didCommitLoadForFrame(WebView webView, IWebFrame frame)
        {}

        public void didFailLoadWithError(WebView webView, WebError error, IWebFrame forFrame)
        {
            var uri          = error.failingURL();
            var description  = error.localizedDescription();

            if (uri.Trim() != string.Empty)
            {
                throw new Exception(uri + Environment.NewLine +
                                    description != null ? description : string.Empty);
            }
        }

        public void didFailProvisionalLoadWithError(WebView webView, WebError error, IWebFrame frame)
        {
            var uri          = error.failingURL();
            var description  = error.localizedDescription();

            if (uri.Trim() != string.Empty)
            {
                throw new Exception(uri + Environment.NewLine +
                                    description != null ? description : string.Empty);
            }
        }

        public void didFinishLoadForFrame(WebView webView, IWebFrame frame)
        {
            WebFrameLoaded.Invoke();
        }

        public void didReceiveIcon(WebView webView, int hBitmap, IWebFrame frame)
        {}

        public void didReceiveServerRedirectForProvisionalLoadForFrame(WebView webView, IWebFrame frame)
        {}

        public void didReceiveTitle(WebView webView, string title, IWebFrame frame)
        {}

        public void didStartProvisionalLoadForFrame(WebView webView, IWebFrame frame)
        {}

        public void willCloseFrame(WebView webView, IWebFrame frame)
        {}

        public void willPerformClientRedirectToURL(WebView webView, string url, double delaySeconds, DateTime fireDate, IWebFrame frame)
        {}

        public void windowScriptObjectAvailable(WebView webView, IntPtr context, IntPtr windowScriptObject)
        {}

        public Action WebFrameLoaded { get; set; }
    }
}
