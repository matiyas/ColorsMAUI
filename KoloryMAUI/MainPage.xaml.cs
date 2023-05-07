using ColoryMAUI.Models;
using Color = ColoryMAUI.Models.Color;

namespace ColoryMAUI;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var color = new Color(
            sliderR.Value, 
            sliderG.Value, 
            sliderB.Value
        );

        Settings.Save(color);
    }
}

