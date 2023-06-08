using System.Globalization;

namespace ColorsMAUI.Converters;

class RGBToBrushConverter : IMultiValueConverter
{
    // Convert from the source to the target element
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Contains(null)) return Brush.Black;

        var r = (double)values[0];
        var g = (double)values[1];
        var b = (double)values[2];

        return new SolidColorBrush(Color.FromRgb(r, g, b));
    }

    // Convert from the target element to the source
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
