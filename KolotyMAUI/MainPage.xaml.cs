using KoloryMAUI.Models;

namespace KoloryMAUI;

public partial class MainPage : ContentPage
{
    private bool _updateUI = true;

	public MainPage()
	{
		InitializeComponent();
        ReadSettings();
	}

    private void ReadSettings ()
    {
        var kolor = Settings.Read();

        _updateUI = false;
        sliderR.Value = kolor.R;
        sliderG.Value = kolor.G;
        _updateUI = true;
        sliderB.Value = kolor.B;
    }

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if (!_updateUI) return;

        UpdateRectangleColor();
        UpdateSlidersLabels();
    }

    private void UpdateRectangleColor ()
    {
        var color = Color.FromRgb(sliderR.Value, sliderG.Value, sliderB.Value);
        rectangle.Fill = new SolidColorBrush(color);
    }

    private void UpdateSlidersLabels ()
    {
        labelR.Text = GetSliderLabelText(sliderR.Value);
        labelG.Text = GetSliderLabelText(sliderG.Value);
        labelB.Text = GetSliderLabelText(sliderB.Value);
    }

    private static string GetSliderLabelText(double sliderValue)
    {
        return Math.Round(255 * sliderValue).ToString();
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        var kolor = new Kolor(
            sliderR.Value, 
            sliderG.Value, 
            sliderB.Value
        );

        Settings.Save(kolor);
    }
}

