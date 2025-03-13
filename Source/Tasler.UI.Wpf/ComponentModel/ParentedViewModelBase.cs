using System.ComponentModel;
using Tasler.ComponentModel;

namespace Tasler.Windows.ComponentModel
{
	public abstract class ParentedViewModelBase<TParent> : INotifyPropertyChanged, IChild<TParent>
		where TParent : class, INotifyPropertyChanged
	{
		#region Constructors
		protected ParentedViewModelBase()
		{
		}

		protected ParentedViewModelBase(TParent parent)
		{
			this.Parent = parent;
		}

		#endregion Constructors

		#region Overridables
		protected virtual bool OnParentSet()
		{
			return true;
		}
		#endregion Overridables

		protected PropertyChangedEventHandler PropertyChanged;

		#region INotifyPropertyChanged Members
		event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
		{
			add { this.PropertyChanged += value; }
			remove { this.PropertyChanged -= value; }
		}
		#endregion INotifyPropertyChanged Members

		#region IChild<TParent> Members

		public TParent Parent
		{
			get; private set;
		}

		public bool SetParent(TParent parent)
		{
			if (this.Parent != null)
				return false;

			this.Parent = parent;

			return this.OnParentSet();
		}

		#endregion IChild<TParent> Members

		#region IChild Members

		object IChild.GetParent()
		{
			return this.Parent;
		}

		bool IChild.SetParent(object parent)
		{
			var typedParent = (TParent)parent;
			return this.SetParent(typedParent);
		}

		public object GetParent()
		{
			throw new System.NotImplementedException();
		}

		public bool SetParent(object parent)
		{
			throw new System.NotImplementedException();
		}

		#endregion IChild Members
	}
}
