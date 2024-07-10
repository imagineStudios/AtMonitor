
namespace AtMonitor.Views
{
    public class ToggleButton : Button
    {
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
            nameof(IsSelected),
            typeof(bool),
            typeof(ToggleButton),
            false,
            BindingMode.OneWay,
            propertyChanged: (b, o, n) => ((ToggleButton)b).IsSelected_Changed((bool)n));

        private void IsSelected_Changed(bool isSelected)
        {
            ChangeVisualState();
        }

        protected override void ChangeVisualState()
        {
            if (IsEnabled && IsSelected)
            {
                VisualStateManager.GoToState(this, "Selected");
            }
            else
            {
                base.ChangeVisualState();
            }
        }

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }
    }
}
