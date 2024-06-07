namespace AtMonitor.Views;

public partial class MissionPage : ContentPage
{
	public MissionPage()
	{
		InitializeComponent();
	}

    private void AddUnitButton_Clicked(object sender, EventArgs e)
    {
        var page = Handler?.MauiContext?.Services.GetService<UnitRegistrationPage>();
        Navigation.PushAsync(page);
    }
}