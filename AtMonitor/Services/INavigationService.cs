
using AtMonitor.Models;

namespace AtMonitor.Services
{
    public interface INavigationService
    {
        Task<Page> NavigateToPage<T>(object? parameters = null) where T : Page;

        Task<Page> NavigateToPeoplePicker(Unit unit);

        Task PopAsync();
    }
}