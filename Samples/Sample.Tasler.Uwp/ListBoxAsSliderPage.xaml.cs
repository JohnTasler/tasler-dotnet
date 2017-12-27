using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Sample.Tasler.Uwp
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class ListBoxAsSliderPage : Page
    {
        public ListBoxAsSliderPage()
        {
            this.InitializeComponent();
        }

		private void ListViewItem_Loaded(object sender, RoutedEventArgs e)
		{
			var element = sender as UIElement;
			element.StartBringIntoView(new BringIntoViewOptions { TargetRect = new Rect(0, 200, 400, 24) });
		}
	}
}
