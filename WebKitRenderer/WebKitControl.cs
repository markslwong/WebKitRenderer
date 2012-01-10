using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WebKit.Interop;

namespace WebKit
{
    internal class WebKitControl : UserControl
    {
        public WebKitControl(Size size)
        {
            _activationContext     = new ActivationContextHelper();
            _webPolicyDelegate     = new WebPolicyDelegate();
            _webFrameLoadDelegate  = new WebFrameLoadDelegate();
            _webUIDelegate         = new WebUIDelegate();
            _webDownloadDelegate   = new WebDownloadDelegate();

            _webFrameLoadDelegate.WebFrameLoaded = this.NavigationComplete;

            Application.OleRequired(); // Required otherwise WebKit will throw an OutOfMemoryException

            _activationContext.Activate();
            _webView = new WebViewClass();
            _activationContext.Deactivate();

            this.Width   = size.Width;
            this.Height  = size.Height;
            this.BackColor = Color.Transparent;
            this.Load    += OnLoad;

            RecreateHandle();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs args)
        {
            // Prevent background from being painted
        }

        private void OnLoad(object sender, EventArgs eventArgs)
        {
            Marshal.AddRef(Marshal.GetIUnknownForObject(_webPolicyDelegate));
            _webView.setPolicyDelegate(_webPolicyDelegate);

            Marshal.AddRef(Marshal.GetIUnknownForObject(_webFrameLoadDelegate));
            _webView.setFrameLoadDelegate(_webFrameLoadDelegate);

            Marshal.AddRef(Marshal.GetIUnknownForObject(_webUIDelegate));
            _webView.setUIDelegate(_webUIDelegate);

            Marshal.AddRef(Marshal.GetIUnknownForObject(_webDownloadDelegate));
            _webView.setDownloadDelegate(_webDownloadDelegate);

            _webView.setHostWindow(this.Handle.ToInt32());
            
            var frameRect = new tagRECT()
                {
                    top     = 0,
                    left    = 0,
                    bottom  = Height,
                    right   = Width
                };
            
            _webView.initWithFrame(frameRect, null, null);
            _webView.setTransparent(TRUE);

            //_webView.setUsesLayeredWindow(TRUE);

            _webFrame = _webView.mainFrame();
        }

        public void Navigate(string uri)
        {
            _activationContext.Activate();

            var request = new WebURLRequestClass();
            
            request.initWithURL(uri, _WebURLRequestCachePolicy.WebURLRequestUseProtocolCachePolicy, TIMEOUT);

            _webView.mainFrame().loadRequest(request);

            _activationContext.Deactivate();
        }

        public void Navigate(string htmlContents, string baseUri)
        {
            _activationContext.Activate();

            _webView.mainFrame().loadHTMLString(htmlContents, baseUri);

            _activationContext.Deactivate();
        }

        private void NavigationComplete()
        {
            this.NagivationComplete.Invoke(this, new EventArgs());
        }

        private const int     TRUE     = 1;
        private const int     FALSE    = 0;
        private const double  TIMEOUT  = 60.0;

        public event EventHandler NagivationComplete;

        private readonly ActivationContextHelper _activationContext;
        private readonly WebViewClass            _webView;
        private readonly WebPolicyDelegate       _webPolicyDelegate;
        private readonly WebFrameLoadDelegate    _webFrameLoadDelegate;
        private readonly WebUIDelegate           _webUIDelegate;
        private readonly WebDownloadDelegate     _webDownloadDelegate;

        private IWebFrame                        _webFrame;
    }
}
