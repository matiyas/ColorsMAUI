using System.Diagnostics;
using System.Globalization;

namespace ColorsMAUI.Converters;

class DoubleToByteString : IValueConverter
{
    public static string ToByteString(double value)
    {
        return Math.Round(255 * value).ToString();
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var dValue = (double)value;
        Trace.WriteLine(value);
        return ToByteString(dValue);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
