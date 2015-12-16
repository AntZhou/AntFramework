using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gobang.WPF
{
    using System.Windows.Media;

    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static SolidColorBrush ChessboardColorBrush = new SolidColorBrush(Colors.Bisque);
    }
}
