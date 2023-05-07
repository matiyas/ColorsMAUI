using System.Xml;

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
        var (r, g, b) = KoloryMAUI.Settings.Read();

        _updateUI = false;
        sliderR.Value = r;
        sliderG.Value = g;
        _updateUI = true;
        sliderB.Value = b;
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
        KoloryMAUI.Settings.Save(
            sliderR.Value, 
            sliderG.Value, 
            sliderB.Value
        );
    }
}

