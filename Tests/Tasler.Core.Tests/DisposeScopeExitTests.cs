#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Tasler.Tests;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public class DisposeScopeExitTests
{
	[Fact]
	public void DisposeActionOnly()
	{
		int inScope = 0;
		using (var scope = new DisposeScopeExit(() => --inScope))
		{
			Assert.Equal(0, inScope);
			++inScope;
			Assert.Equal(1, inScope);
		}
		Assert.Equal(0, inScope);
	}

	[Fact]
	public void InitializeAndDisposeActions()
	{
		int inScope = 0;
		using (var scope = new DisposeScopeExit(() => ++inScope, () => --inScope))
		{
			Assert.Equal(1, inScope);
			++inScope;
			Assert.Equal(2, inScope);
		}
		Assert.Equal(1, inScope);
	}

	[Fact]
	public void InitializeAndDisposeActionsWithEarlyExit()
	{
		int inScope = 0;
		using (var scope = new DisposeScopeExit(() => ++inScope, () => --inScope))
		{
			Assert.Equal(1, inScope);
			++inScope;
			Assert.Equal(2, inScope);

			scope.DetachDisposeAction();
			Assert.Equal(2, inScope);
		}
		Assert.Equal(2, inScope);
	}

	[Fact]
	public void InitializeAndDisposeActionsWithEarlyDispose()
	{
		int inScope = 0;
		using (var scope = new DisposeScopeExit(() => ++inScope, () => --inScope))
		{
			Assert.Equal(1, inScope);
			++inScope;
			Assert.Equal(2, inScope);

			scope.Dispose();
			Assert.Equal(1, inScope);
		}
		Assert.Equal(1, inScope);
	}
}
