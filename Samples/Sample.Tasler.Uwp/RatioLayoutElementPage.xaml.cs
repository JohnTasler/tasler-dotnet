using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Sample.Tasler.Uwp
{
    public sealed partial class RatioLayoutElementPage : Page
    {
        public RatioLayoutElementPage()
        {
            this.InitializeComponent();
        }

        private void SetState(ToggleSwitch toggleSwitch)
        {
            var newState = toggleSwitch.IsOn ? "Expanded" : "Collapsed";
            var groups = VisualStateManager.GetVisualStateGroups(rootElement);
            var wentToState = VisualStateManager.GoToState(this, newState, false);
        }

        private void ToggleSwitch_LoadedOrToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = (ToggleSwitch)sender;
            this.SetState(toggleSwitch);
        }
    }
}
