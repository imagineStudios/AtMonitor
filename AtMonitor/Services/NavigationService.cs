﻿using AtMonitor.ViewModels;
using AtMonitor.Views;
using System.Collections.ObjectModel;

namespace AtMonitor.Services;

public class NavigationService(IServiceProvider services) : INavigationService
{
    readonly IServiceProvider _services = services;

    protected INavigation Navigation
    {
        get
        {
            var navigation = Application.Current?.MainPage?.Navigation;
            if (navigation is not null)
            {
                return navigation;
            }
            else
            {
                throw new Exception();
            }
        }
    }

    public async Task<Page> NavigateToPage<T>(object? parameter = null)
        where T : Page
    {
        var o = _services.GetService<T>();
        if (o is Page page)
        {
            page.NavigatedTo += Page_NavigatedTo;
            GetPageViewModelBase(page)?.OnNavigatingTo(parameter);
            await Navigation.PushAsync(page, true);
            page.NavigatedFrom += Page_NavigatedFrom;
            return page;
        }

        throw new InvalidOperationException($"Unable to resolve type {nameof(T)}");
    }

    public Task PopAsync()
    {
        return Navigation.PopAsync();
    }

    public Task<Page> NavigateToPeoplePicker(Collection<PersonViewModel> people)
    {
        return NavigateToPage<PeoplePickerPage>(people);
    }

    private PageViewModel? GetPageViewModelBase(Page? p)
        => p?.BindingContext as PageViewModel;

    private void Page_NavigatedTo(object? sender, NavigatedToEventArgs e)
        => GetPageViewModelBase(sender as Page)?.OnNavigatedTo();

    private void Page_NavigatedFrom(object? sender, NavigatedFromEventArgs e)
    {
        //To determine forward navigation, we look at the 2nd to last item on the NavigationStack
        //If that entry equals the sender, it means we navigated forward from the sender to another page
        bool isForwardNavigation = Navigation.NavigationStack.Count > 1
            && Navigation.NavigationStack[^2] == sender;
        if (sender is Page thisPage)
        {
            if (!isForwardNavigation)
            {
                thisPage.NavigatedTo -= Page_NavigatedTo;
                thisPage.NavigatedFrom -= Page_NavigatedFrom;
            }

            GetPageViewModelBase(thisPage)?.OnNavigatedFrom(isForwardNavigation);
        }
    }
}