using System.ComponentModel;

namespace Tasler.ComponentModel
{
    public abstract class ChildViewModel<TParent> : Child<TParent>, INotifyPropertyChanged
        where TParent : class
    {
        #region Constructors
        public ChildViewModel()
        {
        }

        public ChildViewModel(TParent parent)
            : base(parent)
        {
        }
        #endregion Constructors

        /// <summary>
        /// Raised when a property on this object has a new value.
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { this.PropertyChanged += value; }
            remove { this.PropertyChanged -= value; }
        }

        protected PropertyChangedEventHandler PropertyChanged { get; private set; }
    }
}
