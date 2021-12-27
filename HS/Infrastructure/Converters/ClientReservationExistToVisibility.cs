using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using HS.Context.Entities;

namespace HS.Infrastructure.Converters
{
    public class ClientReservationExistToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var c = (Client) value;
            if (c.Reservations.FirstOrDefault() != default) return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}