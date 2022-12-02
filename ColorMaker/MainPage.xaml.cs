namespace ColorMaker;
using Microsoft.Maui.Graphics;
using System.Drawing;

public partial class MainPage : ContentPage
{
    public short Red { get; set; }
    public short Blue { get; set; }
    public short Green{ get; set; }
    public string HEX { get; set; }

    public MainPage()
	{
		InitializeComponent();
	}

    private void sliderBlue_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Blue = (short)sliderBlue.Value;
        GenerateRGB();
    }

    private void sliderRed_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Red= (short)sliderRed.Value;
        GenerateRGB();

    }

    private void sliderGreen_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Green = (short)sliderGreen.Value;
        GenerateRGB();
    }
    private void GenerateRGB()
    {
        System.Drawing.Color myColor = System.Drawing.Color.FromArgb(Red, Green, Blue);
        lbl_hex.Text = "#"+myColor.R.ToString("X2") + myColor.G.ToString("X2") + myColor.B.ToString("X2");
        Container.BackgroundColor= Microsoft.Maui.Graphics.Color.FromRgb(Red,Green,Blue);
    }

    private void btnRandom_Clicked(object sender, EventArgs e)
    {
        Random random = new ();
        Blue = (short)random.NextInt64(0,256);
        sliderBlue.Value = Blue;
        Green= (short)random.NextInt64(0,256);
        sliderGreen.Value = Green;
        Red = (short)random.NextInt64(0,256);
        sliderRed.Value = Red;
        GenerateRGB();
    }

    private async void btnCopy_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(lbl_hex.Text);
    }
}

