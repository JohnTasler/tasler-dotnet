using System.ComponentModel;

namespace Tasler.ComponentModel
{
    public interface IChild
    {
        object? GetParent();

        bool SetParent(object parent);
    }

    public interface IChild<TParent> : IChild
        where TParent : class
    {
        TParent? Parent { get; }

        bool SetParent(TParent parent);
    }
}
