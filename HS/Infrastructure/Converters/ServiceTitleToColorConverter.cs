using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace HS.Infrastructure.Converters
{
    public class ServiceTitleToColorConverter : IValueConverter
    {
        public object Convert(object v, Type t, object p, CultureInfo c)
        {
            Color color;
            var type = (string) v;
            if (type == "Gym") color = Colors.DarkGray;
            if (type == "Swimming Pool") color = Colors.DodgerBlue;
            if (type == "Food") color = Colors.Orange;
            return color;
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo c)
        {
            throw new NotImplementedException();
        }
    }
}