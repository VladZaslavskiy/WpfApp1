using System;
using System.Windows.Data;

namespace WpfApp1
{
    class StringToIntValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //int intValue;
            //bool success = int.TryParse(value.ToString(), out intValue);
            //if (success)
            //    return intValue;
            //else
            //    return value;
            int intValue = int.Parse(value.ToString());
            return intValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
                value.ToString();
            return value;
        }
    }
}
