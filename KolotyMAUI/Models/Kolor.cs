namespace KoloryMAUI.Models;

internal class Kolor
{
    double _r, _g, _b;

    public double R
    {
        get => OgraniczDoZakresu(_r);
        set => _r = value;
    }

    public double G
    {
        get => OgraniczDoZakresu(_g);
        set => _g = value;
    }

    public double B
    {
        get => OgraniczDoZakresu(_b);
        set => _b = value;
    }

    public Kolor (double r, double g, double b)
    {
        _r = r;
        _g = g;
        _b = b;
    }

    public static Kolor Czarny => new(0, 0, 0);

    static double OgraniczDoZakresu(double x)
    {
        return new[] { 0, x, 1 }.OrderBy(e => e).First();
    }
}
