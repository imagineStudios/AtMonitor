using AtMonitor.Models;
using System.Collections.ObjectModel;

namespace AtMonitor.Services
{
    public interface INavigationService
    {
        Task<Page> NavigateToPage<T>(object? parameters = null) where T : Page;

        Task<Page> NavigateToPeoplePicker(Collection<Person> people);

        Task PopAsync();
    }
}