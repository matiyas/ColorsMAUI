using System.Diagnostics;

namespace ColorsMAUI.Models;

internal class Color

{
    double _r, _g, _b;

    public double R
    {
        get => LimitToRange(_r);
        set => _r = value;
    }

    public double G
    {
        get => LimitToRange(_g);
        set => _g = value;
    }

    public double B
    {
        get => LimitToRange(_b);
        set => _b = value;
    }

    public Color (double r, double g, double b)
    {
        _r = r;
        _g = g;
        _b = b;
    }

    public static Color Czarny { get => new(0, 0, 0); }

    static double LimitToRange(double x) => new[] { 0, x, 1 }.OrderBy(e => e).ToArray()[1];
}
