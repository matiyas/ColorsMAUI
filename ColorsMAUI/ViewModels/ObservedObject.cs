using System.ComponentModel;

namespace ColorsMAUI.ViewModels;

// Should implement INotifyPropertyChanged if have to be used in the BindingContext
internal abstract class ObservedObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(params string[] propertiesNames)
    {
        if (PropertyChanged == null) return;

        foreach (var propertyName in propertiesNames)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    }
}
