using System.Globalization;
using System.Xml.Linq;

namespace KoloryMAUI.Models;

static class Settings
{
    private static readonly string _filePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        "colors.xml"
    );
    private static readonly IFormatProvider _formatProvider = CultureInfo.InvariantCulture;

    public static void Save(this Kolor kolor)
    {

        XDocument xml = new(
            new XComment($"Saved: {DateTime.Now}"),
            new XElement("settings",
                new XElement("r", kolor.R.ToString(_formatProvider)),
                new XElement("g", kolor.G.ToString(_formatProvider)),
                new XElement("b", kolor.B.ToString(_formatProvider))
            )
        );
        xml.Save(_filePath);
    }

    public static Kolor Read()
    {
        var defaultValue = Kolor.Czarny;

        if (!File.Exists(_filePath)) return defaultValue;

        try
        {
            XDocument xml = XDocument.Load(_filePath);

            double r = double.Parse(xml.Root.Element("r").Value, _formatProvider);
            double g = double.Parse(xml.Root.Element("g").Value, _formatProvider);
            double b = double.Parse(xml.Root.Element("b").Value, _formatProvider);

            return new Kolor(r, g, b);
        }
        catch
        {
            return defaultValue;
        }
    }
}
