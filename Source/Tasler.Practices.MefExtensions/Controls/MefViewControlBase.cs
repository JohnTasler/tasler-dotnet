using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace Tasler.Practices.Prism.MefExtensions.Controls
{
	public abstract class MefViewControlBase<TViewModel> : UserControl
		where TViewModel : class
	{
		[Import]
		public TViewModel ViewModel
		{
			get { return (TViewModel)this.DataContext; }
			set { this.DataContext = value; }
		}
	}
}
