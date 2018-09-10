namespace Tasler.ComponentModel
{
    public abstract class Child<TParent> : IChild<TParent>
        where TParent : class
    {
        #region Constructors
        protected Child()
        {
        }

        protected Child(TParent parent)
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

        object IChild.GetParent()
        {
            return this.Parent;
        }

        bool IChild.SetParent(object parent)
        {
            var typedParent = (TParent)parent;
            return this.SetParent(typedParent);
        }

        #endregion IParentedObject Members
    }
}
