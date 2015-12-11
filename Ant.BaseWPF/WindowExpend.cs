namespace Ant.BaseWPF
{
    using System;
    using System.Windows;
    using System.Windows.Forms;
    using System.Windows.Interop;

    public static class WindowExpend
    {
        #region Static Fields

        private static Window fullWindow;

        private static Rect windowRect;

        private static ResizeMode windowResizeMode;

        private static WindowState windowState;

        private static WindowStyle windowStyle;

        private static bool windowTopmost;

        #endregion

        #region Public Methods and Operators

        public static void ExitFullScreen(this Window window)
        {
            if (!IsFullScreen(window))
            {
                return;
            }
            window.WindowState = windowState;
            window.WindowStyle = windowStyle;
            window.ResizeMode = windowResizeMode;
            window.Topmost = windowTopmost;
            window.Left = windowRect.X;
            window.Top = windowRect.Y;
            window.Width = windowRect.Width;
            window.Height = windowRect.Height;

            fullWindow = null;
        }

        public static void GoFullScreen(this Window window)
        {
            if (IsFullScreen(window))
            {
                return;
            }

            windowState = window.WindowState;
            windowStyle = window.WindowStyle;
            windowTopmost = window.Topmost;
            windowResizeMode = window.ResizeMode;
            windowRect.X = window.Left;
            windowRect.Y = window.Top;
            windowRect.Width = window.Width;
            windowRect.Height = window.Height;

            window.WindowState = WindowState.Maximized;
            window.WindowStyle = WindowStyle.None;
            windowTopmost = false;
            windowResizeMode = ResizeMode.NoResize;
            IntPtr handle = new WindowInteropHelper(window).Handle;
            Screen screen = Screen.FromHandle(handle);
            window.Width = screen.Bounds.Width;
            window.Height = screen.Bounds.Height;

            fullWindow = window;
        }

        public static bool IsFullScreen(this Window window)
        {
            return fullWindow != null;
        }

        #endregion


    }

}