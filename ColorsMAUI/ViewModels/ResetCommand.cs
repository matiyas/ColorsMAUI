using System;
using System.ComponentModel;
using System.Windows.Input;

namespace ColorsMAUI.ViewModels;

internal class ResetCommand : ICommand
{
    private readonly ColorViewModel _viewModel;
    private bool _previousCanExecuteValue;

    public ResetCommand (ColorViewModel viewModel)
    {
        _viewModel = viewModel;
        _previousCanExecuteValue = CanExecute(null);
        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
    }

    private void ViewModel_PropertyChanged (object sender, PropertyChangedEventArgs e)
    {
        bool canExecuteValue = CanExecute(null);

        if (CanExecuteChanged != null && _previousCanExecuteValue != canExecuteValue)
            CanExecuteChanged(_viewModel, EventArgs.Empty);

        _previousCanExecuteValue = canExecuteValue;
    }

    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        return (_viewModel.R != 0) || (_viewModel.G != 0) || (_viewModel.B != 0);
    }

    public void Execute(object parameter)
    {
        if (_viewModel == null) return;

        _viewModel.R = 0;
        _viewModel.G = 0;
        _viewModel.B = 0;
    }
}

