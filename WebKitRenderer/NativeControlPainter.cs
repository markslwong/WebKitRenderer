using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public static class NativeControlPainter
{
    private const int PRF_NON_CLIENT       = 0x2;
    private const int PRF_CLIENT           = 0x4;
    private const int PRF_CHILDREN         = 0x10;
    private const int WM_PRINT             = 0x317;
    private const int WM_PRINTCLIENT       = 0x318;
    private const int COMBINED_PRINTFLAGS  = PRF_NON_CLIENT | PRF_CLIENT | PRF_CHILDREN;

    [DllImport("USER32.DLL")]
    private static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, int lParam);
    
    [DllImport("GDI32.dll")]
    private static extern int SetBkMode(IntPtr hDc, int iBkMode);

    [DllImport("GDI32.dll")]
    private static extern int SetBkColor(IntPtr hDc, int crColor);
    
    public static void PaintControl(Graphics graphics, Control control)
    {
        var mode = graphics.CompositingMode = CompositingMode.SourceCopy;

        IntPtr hWnd  = control.Handle;
        IntPtr hDC   = graphics.GetHdc();

        SendMessage(hWnd, WM_PRINT, hDC, COMBINED_PRINTFLAGS);

        graphics.ReleaseHdc(hDC);
    }


}
