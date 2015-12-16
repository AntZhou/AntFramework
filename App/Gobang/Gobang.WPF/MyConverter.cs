using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gobang.WPF
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Ink;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class ZeroPontNineTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = (double)value * 0.9;
            return (object)result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color co = Colors.Transparent;

            if (value==null)
            {
                return new SolidColorBrush(co);
            }
            co = (int)value==1 ? Colors.Black : Colors.White;
            return new SolidColorBrush(co);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
