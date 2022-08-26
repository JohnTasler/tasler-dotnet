using System.Diagnostics;
using System.Threading;
using Tasler.UI.Core;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Sample.Tasler.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DispatcherThreadPage : Page
    {
        DispatcherThread _dispatcherThread;

        public DispatcherThreadPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var unused = _dispatcherThread.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Debug.WriteLine($"Running a dispatch request on a seconday dispatcher: {Thread.CurrentThread.Name}");
            });
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _dispatcherThread = new DispatcherThread();
            _dispatcherThread.Start(ApartmentState.MTA);
            var hasThreadAccess = _dispatcherThread.HasThreadAccess;
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            _dispatcherThread.Dispose();
            _dispatcherThread = null;
        }
    }
}
