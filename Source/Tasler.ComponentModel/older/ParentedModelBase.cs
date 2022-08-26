using System.ComponentModel;

namespace Tasler.ComponentModel
{

	public abstract class ParentedModelBase<TParent> : ModelBase, IParentedObject<TParent>
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
