using AtMonitor.ViewModels;

namespace AtMonitor.Views;

public partial class UnitRegistrationPage : ContentPage
{

    public UnitRegistrationPage(UnitRegistrationViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void OkButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void AbortButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}