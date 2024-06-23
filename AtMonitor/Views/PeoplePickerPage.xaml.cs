using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class PeoplePickerPage : ContentPage
{
	public PeoplePickerPage(PeoplePickerViewModel context)
	{
		InitializeComponent();
		BindingContext = context;
	}
}