using System.ComponentModel;

namespace Tasler.ComponentModel
{
	public interface IParentedObject
	{
		object GetParent();

		bool SetParent(object parent);
	}

	public interface IParentedObject<TParent> : IParentedObject
		where TParent : class, INotifyPropertyChanged
	{
		TParent Parent { get; }
		
		bool SetParent(TParent parent);
	}
}
