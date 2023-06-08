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
    private ICommand _save;

    public ICommand Reset
    {
        get
        {
            _reset ??= 
                new RelayCommand(
                    viewModel: this,
                    execute: parameter => { R = 0; G = 0; B = 0; },
                    canExecute: parameter => R != 0 || G != 0 || B != 0);
                
            return _reset;
        }
    }

    public ICommand Save
    {
        get
        {
            _save ??=
                new RelayCommand(
                    viewModel: this,
                    execute: parameter => Settings.Save(_model));

            return _save;
        }
    }


    #endregion Commands
}
