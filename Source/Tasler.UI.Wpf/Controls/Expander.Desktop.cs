using System.Windows.Input;
using Tasler.Windows.Commands;

namespace Tasler.Windows.Controls
{
	public sealed class Expander : System.Windows.Controls.Expander
	{
		#region Construction
		/// <summary>
		/// Initializes a new instance of the <see cref="Expander"/> class.
		/// </summary>
		public Expander()
		{
		}
		#endregion Construction

		#region Commands

		public ICommand CollapseCommand
		{
			get
			{
				return this.collapseCommand ??
					(this.collapseCommand = new RelayCommand(() => this.IsExpanded = false, () => this.IsExpanded));
			}
		}
		private RelayCommand collapseCommand;

		public ICommand ExpandCommand
		{
			get
			{
				return this.expandCommand ??
					(this.expandCommand = new RelayCommand(() => this.IsExpanded = true, () => !this.IsExpanded));
			}
		}
		private RelayCommand expandCommand;

		public ICommand ToggleCommand
		{
			get
			{
				return this.toggleCommand ??
					(this.toggleCommand = new RelayCommand(() => this.IsExpanded = !this.IsExpanded));
			}
		}
		public RelayCommand toggleCommand;

		#endregion Commands

		#region Overrides

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Controls.Expander.Collapsed" /> event when the
		/// <see cref="P:System.Windows.Controls.Expander.IsExpanded" /> property changes from <c>true</c> to <c>false</c>.
		/// </summary>
		protected override void OnCollapsed()
		{
			this.RaiseEvents();
			base.OnCollapsed();
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Controls.Expander.Expanded" /> event when the
		/// <see cref="P:System.Windows.Controls.Expander.IsExpanded" /> property changes from <c>false</c> to <c>true</c>.
		/// </summary>
		protected override void OnExpanded()
		{
			this.RaiseEvents();
			base.OnExpanded();
		}

		#endregion Overrides

		#region Private Implementation

		private void RaiseEvents()
		{
			if (this.collapseCommand != null)
				this.collapseCommand.RaiseCanExecuteChanged();
			if (this.expandCommand != null)
				this.expandCommand.RaiseCanExecuteChanged();
		}

		#endregion Private Implementation
	}
}
