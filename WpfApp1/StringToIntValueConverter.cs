using System;
using System.Windows.Data;

namespace WpfApp1
{
    public class StringToIntValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //int intValue;           
            //if (Int32.TryParse(value.ToString(), out intValue))
            //    return intValue;
            //else
            //    return value;
            // int intValue = int.Parse(value.ToString());
            int intValue = (int)value;
            return intValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int intValue;
            if (Int32.TryParse(value.ToString(), out intValue))
                return intValue;
            else
                return value;
        }
    }
}
