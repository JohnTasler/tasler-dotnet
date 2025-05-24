namespace Tasler.ComponentModel;

public interface IChild
{
	object? GetParent();
}

public interface IChild<TParent> : IChild
	where TParent : class
{
	TParent Parent { get; }
}
