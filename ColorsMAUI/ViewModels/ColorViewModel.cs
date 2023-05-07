using ColorsMAUI.Models;
using System.Diagnostics;
using Color = ColorsMAUI.Models.Color;

namespace ColorsMAUI.ViewModels;

internal class ColorViewModel : ObservedObject
{
    private readonly Color _model = Settings.Read();

    #region Properties
    public double R
    {
        get => _model.R;
        set
        {
            _model.R = value;
            Trace.WriteLine($"VM: {_model.R}");
            OnPropertyChanged(nameof(R));
        }
    }
    public double G
    {
        get => _model.G;
        set
        {
            _model.G = value;
            OnPropertyChanged(nameof(G));
        }
    }
    public double B
    {
        get => _model.B;
        set
        {
            _model.B = value;
            OnPropertyChanged(nameof(B));
        }
    }
    #endregion Properties
}
