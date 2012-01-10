using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using WebKit;

namespace WebKitRendererTest
{
    public partial class OutputPreview : Form
    {
        public OutputPreview()
        {
            InitializeComponent();

            var renderer = new WebKitRenderer(new Size(this.Width, this.Height));

            renderer.Navigate("http://www.google.ca/");

            var bitmap = new Bitmap(640, 480);

            var graphics = Graphics.FromImage(bitmap);
            
            renderer.Render(graphics);

            this.pictureBox.Image = bitmap;
        }
    }
}
