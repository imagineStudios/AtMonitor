using AtMonitor.Models;
using AtMonitor.Services;
using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class PeoplePickerPage : ContentPage
{
	public PeoplePickerPage(IStore<Person> store)
	{
		InitializeComponent();

		var people = store.GetAll()
			.OrderBy(p => p.LastName)
			.ThenBy(p => p.FirstName);

		BindingContext = new PickerPageViewModel<Person>(people);
	}
}