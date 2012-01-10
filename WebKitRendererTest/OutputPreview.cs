using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WebKit;

namespace webkitrenderertest
{
    public partial class OutputPreview : Form
    {
        public OutputPreview()
        {
            InitializeComponent();

            var renderer = new WebKitRenderer(new Size(this.Width, this.Height));

            renderer.Navigate("file:///C:/Workspace/XQ.SlipStream/Projects/Windows/bin/Debug/detailcard.html");

            var bitmap = new Bitmap(640, 480);

            var graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.Transparent);

            var pixel = bitmap.GetPixel(0, 0);

            if (pixel.A != 0)
            {
                throw new Exception(pixel.A.ToString());
            }

            bitmap.Save("transparent.png", ImageFormat.Png);

            renderer.Render(graphics);

            pixel = bitmap.GetPixel(0, 0);

            if (pixel.A != 0)
            {
                throw new Exception(pixel.A.ToString());
            }

            bitmap.Save("moogle.png", ImageFormat.Png);

            this.pictureBox.Image = bitmap;
        }
    }
}
