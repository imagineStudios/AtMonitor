using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class MissionPage : ContentPage
{
	public MissionPage(MissionPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}