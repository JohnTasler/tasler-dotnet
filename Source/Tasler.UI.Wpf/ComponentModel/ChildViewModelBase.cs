using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Tasler.ComponentModel;

namespace Tasler.Windows.ComponentModel;

public abstract class ChildViewModelBase<TParent> : ObservableObject, IChild<TParent>
	where TParent : class, INotifyPropertyChanged
{
	#region Constructors
	protected ChildViewModelBase(TParent parent)
	{
		this.Parent = parent;
	}

	#endregion Constructors

	#region IChild<TParent> Members

	public TParent Parent
	{
		get; private set;
	}

	#endregion IChild<TParent> Members

	#region IChild Members

	object IChild.GetParent()
	{
		return this.Parent;
	}

	#endregion IChild Members
}
