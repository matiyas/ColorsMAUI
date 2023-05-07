using System.Globalization;
using System.Xml.Linq;

namespace KoloryMAUI;

class Settings
{
    private static readonly string _filePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "colors.xml"
    );
    private static readonly IFormatProvider _formatProvider = CultureInfo.InvariantCulture;

    public static void Save (double r, double g, double b)
    {

        XDocument xml = new(
            new XComment($"Saved: {DateTime.Now}"),
            new XElement("settings",
                new XElement("r", r.ToString(_formatProvider)),
                new XElement("g", g.ToString(_formatProvider)),
                new XElement("b", b.ToString(_formatProvider))
            )
        );
        xml.Save(_filePath);
    }

    public static (double r, double g, double b) Read ()
    {
        var defaultValue = (0, 0, 0);

        if (!File.Exists(_filePath)) return defaultValue;

        try
        {
            XDocument xml = XDocument.Load(_filePath);

            double r = double.Parse(xml.Root.Element("r").Value, _formatProvider);
            double g = double.Parse(xml.Root.Element("g").Value, _formatProvider);
            double b = double.Parse(xml.Root.Element("b").Value, _formatProvider);

            return (r, g, b);
        }
        catch
        {
            return defaultValue;
        }
    }
}
