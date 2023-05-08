using ColorsMAUI.Models;
using System.Diagnostics;
using System.Windows.Input;
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

    #region Commands
    private ICommand _reset;

    public ICommand Reset
    {
        get
        {
            if (_reset == null) _reset = new ResetCommand(this);
            return _reset;
        }
    }
    #endregion Commands
}
