using ColorsMAUI.Models;
using Color = ColorsMAUI.Models.Color;

namespace ColorsMAUI;

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

