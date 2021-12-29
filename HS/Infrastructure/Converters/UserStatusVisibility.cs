using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace HS.Infrastructure.Converters
{
    public class UserStatusVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = (string) value;
            if (s == "guest") return Visibility.Visible;
            else return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}