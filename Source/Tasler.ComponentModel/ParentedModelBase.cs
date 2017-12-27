using System.ComponentModel;

namespace Tasler.ComponentModel
{

	public abstract class ParentedModelBase<TParent> : INotifyPropertyChanged, IParentedObject<TParent>
		where TParent : class, INotifyPropertyChanged
	{
		#region Constructors
		protected ParentedModelBase()
		{
		}

		protected ParentedModelBase(TParent parent)
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

		#region INotifyPropertyChanged Members

		#pragma warning disable CS0067
		public event PropertyChangedEventHandler PropertyChanged;
		#pragma warning restore CS0067

		#endregion INotifyPropertyChanged Members

		#region IParentedObject<TParent> Members

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

		#endregion IParentedObject<TParent> Members

		#region IParentedObject Members

		object IParentedObject.GetParent()
		{
			return this.Parent;
		}

		bool IParentedObject.SetParent(object parent)
		{
			var typedParent = (TParent)parent;
			return this.SetParent(typedParent);
		}

		#endregion IParentedObject Members
	}

	//public abstract class ParentedModelBase<TParent> : ParentedModelBase<TParent, ModelBase>
	//	where TParent : INotifyPropertyChanged
	//{
	//}
}
