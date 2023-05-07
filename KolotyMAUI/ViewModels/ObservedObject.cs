using System.ComponentModel;

namespace KolotyMAUI.ViewModels;

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
