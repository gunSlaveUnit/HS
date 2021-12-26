using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using HS.Context.Entities;

namespace HS.Infrastructure.Converters
{
    public class RoomTypeToColorConverter : IValueConverter
    {
        public object Convert(object v, Type t, object p, CultureInfo c)
        {
            SolidColorBrush color = null;
            var type = (string) v;
            if (type == "Business") color = new SolidColorBrush(Colors.DodgerBlue);
            if (type == "Honeymoon") color = new SolidColorBrush(Colors.Green);
            if (type == "Family") color = new SolidColorBrush(Colors.Coral);
            if (type == "Lux") color = new SolidColorBrush(Colors.Gold);
            return color;
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
        {
            return null;
        }
    }
}