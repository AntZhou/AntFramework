using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.WPF.Converter
{
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// 可见性转换器
    /// </summary>
    public class VisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                return (bool)value == false ? Visibility.Collapsed : Visibility.Visible;

            return (bool)value ? Visibility.Collapsed : Visibility.Visible;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    class MyConverter
    {
    }
}
