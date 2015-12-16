using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gobang.WPF
{
    using Ant.BaseWPF;

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.InitKey();
            this.Index();
        }

        private void Index()
        {
            this.BaseFrame.Navigate(new Uri("Index.xaml",UriKind.Relative));
        }

        private void InitKey()
        {
            this.KeyDown += this.MainWindowKeyDown;
        }

        private void MainWindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            if (e.Key != Key.Enter || e.KeyboardDevice.Modifiers != ModifierKeys.Control)
            {
                return;
            }
            if (this.IsFullScreen())
            {
                this.ExitFullScreen();
            }
            else
            {
                this.GoFullScreen();
            }
        }
    }
}
