using KoloryMAUI.Models;
using System.ComponentModel;

namespace KolotyMAUI.ViewModels;

internal class KolorViewModel : ObservedObject
{
    private readonly Kolor _model = Settings.Read();

    #region Properties
    public double R
    {
        get => _model.R;
        set
        {
            _model.R = value;
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
