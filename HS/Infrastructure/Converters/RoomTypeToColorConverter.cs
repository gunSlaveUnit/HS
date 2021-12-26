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
            Color color;
            var type = (string) v;
            if (type == "Business") color = Colors.DodgerBlue;
            if (type == "Honeymoon") color = Colors.Green;
            if (type == "Family") color = Colors.Coral;
            if (type == "Lux") color = Colors.Gold;
            return color;
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
        {
            return null;
        }
    }
}