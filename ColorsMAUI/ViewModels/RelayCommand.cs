using System.ComponentModel;
using System.Windows.Input;

namespace ColorsMAUI.ViewModels;

internal class RelayCommand : ICommand
{
    readonly INotifyPropertyChanged _viewModel;
    bool _previousCanExecuteValue;
    readonly Action<object> _execute;
    readonly Predicate<object> _canExecute;

    public RelayCommand
    (
        ColorViewModel viewModel,
        Action<object> execute,
        Predicate<object> canExecute = null)
    {
        _viewModel = viewModel;
        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;

        _previousCanExecuteValue = CanExecute(null);
    }

    public event EventHandler CanExecuteChanged;

    private void ViewModel_PropertyChanged (object sender, PropertyChangedEventArgs e)
    {
        bool canExecuteValue = CanExecute(null);

        if (CanExecuteChanged != null && _previousCanExecuteValue != canExecuteValue)
            CanExecuteChanged(_viewModel, EventArgs.Empty);

        _previousCanExecuteValue = canExecuteValue;
    }


    public bool CanExecute(object parameter)
    {
        return (_canExecute == null) ? true : _canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        _execute(parameter);
    }
}
