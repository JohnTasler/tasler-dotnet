using Tasler.ComponentModel;

namespace Tasler.Windows.ComponentModel
{
	/// <summary>
	/// An abstract class to be used as the base class of most view models.
	/// </summary>
	/// <remarks>
	/// <para>This object explicitly implements the <see cref="IRaisePropertyChanged"/> interface for sole use with the
	/// extension methods defined in the <see cref="RaisePropertyChangedExtensions"/> class.
	/// </para>
	/// <para>NOTE: This class, not the base <see cref="ModelBase"/> class, should have UI-specific functionality, such as
	/// reliance upon the <see cref="Dispatch"/> class, if such functionality is deemed necessary.
	/// </para>
	/// </remarks>
	public abstract class ViewModelBase : ModelBase, IRaisePropertyChanged
	{
	}
}
