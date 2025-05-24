namespace Tasler.ComponentModel
{
	public abstract class ChildBase<TParent> : IChild<TParent>
		where TParent : class
	{
		#region Constructors
		protected ChildBase(TParent parent)
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

		object? IChild.GetParent()
		{
			return this.Parent;
		}

		#endregion IChild Members
	}
}
