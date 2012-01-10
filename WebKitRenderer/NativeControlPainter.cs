using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class NativeControlPainter
{
    private const int PRF_CLIENT    = 0x4;
    private const int PRF_CHILDREN  = 0x10;
    private const int WM_PRINT      = 0x317;

    [DllImport("USER32.DLL")]
    private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, int lParam);
    
    public static void PaintControl(Graphics graphics, Control control)
    {
        var mode  = graphics.CompositingMode = CompositingMode.SourceCopy;

        var hWnd  = control.Handle;
        var hDC   = graphics.GetHdc();

        SendMessage(hWnd, WM_PRINT, hDC, PRF_CLIENT | PRF_CHILDREN);

        graphics.ReleaseHdc(hDC);
    }
}
