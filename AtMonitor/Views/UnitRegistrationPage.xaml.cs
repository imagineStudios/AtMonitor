using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class UnitRegistrationPage : ContentPage
{
    public UnitRegistrationPage(UnitRegistrationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}