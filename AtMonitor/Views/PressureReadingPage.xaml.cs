using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class PressureReadingPage : ContentPage
{
	public PressureReadingPage(PressureReadingPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}