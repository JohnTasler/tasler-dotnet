using CommunityToolkit.Mvvm.Input;

namespace Tasler.Windows.Controls;

public sealed partial class Expander : System.Windows.Controls.Expander
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

	[RelayCommand(CanExecute = nameof(CanCollapse))]
	private void Collapse() => this.IsExpanded = false;
	private bool CanCollapse() => this.IsExpanded;

	[RelayCommand(CanExecute = nameof(CanExpand))]
	private void Expand() => this.IsExpanded = true;
	private bool CanExpand() => !this.IsExpanded;

	[RelayCommand(CanExecute = nameof(CanExpand))]
	private void Toggle() => this.IsExpanded = !this.IsExpanded;

	#endregion Commands

	#region Overrides

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Controls.Expander.Collapsed" /> event when the
	/// <see cref="P:System.Windows.Controls.Expander.IsExpanded" /> property changes from <see langword="true"/> to <see langword="false"/>.
	/// </summary>
	protected override void OnCollapsed()
	{
		this.RaiseEvents();
		base.OnCollapsed();
	}

	/// <summary>
	/// Raises the <see cref="E:System.Windows.Controls.Expander.Expanded" /> event when the
	/// <see cref="P:System.Windows.Controls.Expander.IsExpanded" /> property changes from <see langword="false"/> to <see langword="true"/>.
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
		this.CollapseCommand.NotifyCanExecuteChanged();
		this.ExpandCommand.NotifyCanExecuteChanged();
	}

	#endregion Private Implementation
}
