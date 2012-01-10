using System;
using WebKit.Interop;

namespace WebKit
{
    internal class WebPolicyDelegate : IWebPolicyDelegate
    {
        public void decidePolicyForMIMEType(WebView webView, string type, IWebURLRequest request, IWebFrame frame, IWebPolicyDecisionListener listener)
        {
            listener.use();
        }

        public void decidePolicyForNavigationAction(WebView webView, CFDictionaryPropertyBag actionInformation, IWebURLRequest request, IWebFrame frame, IWebPolicyDecisionListener listener)
        {
            listener.use();
        }

        public void decidePolicyForNewWindowAction(WebView webView, CFDictionaryPropertyBag actionInformation, IWebURLRequest request, string frameName, IWebPolicyDecisionListener listener)
        {
            listener.use();
        }

        public void unableToImplementPolicyWithError(WebView webView, WebError error, IWebFrame frame)
        {}
    }
}
