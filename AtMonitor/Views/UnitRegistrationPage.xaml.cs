using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class UnitRegistrationPage : ContentPage
{
    public UnitRegistrationPage(UnitRegistrationPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}