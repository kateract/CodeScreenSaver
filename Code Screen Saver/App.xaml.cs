using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Display = System.Windows.Forms;
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace Code_Screen_Saver
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private HwndSource winWPFContent;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();

            if (e.Args.Length == 0 || e.Args[0].ToLower().StartsWith("/s"))
            {
                window.Left = Display.Screen.AllScreens.Min(s => s.Bounds.X);
                window.Top = Display.Screen.AllScreens.Min(s => s.Bounds.Y);
                window.Width = Display.Screen.AllScreens.Max(s => s.Bounds.X + s.Bounds.Width - window.Left);
                window.Height = Display.Screen.AllScreens.Max(s => s.Bounds.Y + s.Bounds.Height - window.Top);

            }
            else if (e.Args[0].ToLower().StartsWith("/p"))
            {
                Int32 previewHandle = Convert.ToInt32(e.Args[1]);
                IntPtr pPreviewHnd = new IntPtr(previewHandle);
                Rect lpRect = new Rect();

            }

        }

        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

    }
}
