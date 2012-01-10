using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WebKit
{
    public class WebKitRenderer
    {
        public WebKitRenderer(Size size)
        {
            _webKitControl = new WebKitControl(size);

            _webKitControl.CreateControl();

            _webKitControl.NagivationComplete += OnNagivationComplete;

            _applicationContext = new ApplicationContext();
        }

        public void Navigate(string uri)
        {
            _webKitControl.Navigate(uri);
        }

        public void Navigate(string htmlContents, string baseUri)
        {
            _webKitControl.Navigate(htmlContents, baseUri);
        }

        public void Render(Graphics graphics)
        {
            _renderTargetCache = graphics;
            
            Application.Run(_applicationContext);
        }

        private void OnNagivationComplete(object sender, EventArgs args)
        {
            _renderTargetCache.Clear(Color.Transparent);

            NativeControlPainter.PaintControl(_renderTargetCache, _webKitControl);

            _applicationContext.ExitThread();
        }
        
        private readonly WebKitControl       _webKitControl;
        private readonly ApplicationContext  _applicationContext;
        private Graphics                     _renderTargetCache;
    }
}
