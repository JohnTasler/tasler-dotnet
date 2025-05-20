#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Tasler.Tests;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public class AsyncDisposeScopeExitTests
{
	[Fact]
	public async Task DisposeActionOnly()
	{
		int inScope = 0;
		await using (var scope = new AsyncDisposeScopeExit(() => { --inScope; return Task.CompletedTask; }))
		{
			Assert.Equal(0, inScope);
			++inScope;
			Assert.Equal(1, inScope);
		}
		Assert.Equal(0, inScope);
	}

	[Fact]
	public async Task InitializeAndDisposeActions()
	{
		int inScope = 0;
		await using (var scope = new AsyncDisposeScopeExit(() => ++inScope, () => { --inScope; return Task.CompletedTask; }))
		{
			Assert.Equal(1, inScope);
			++inScope;
			Assert.Equal(2, inScope);
		}
		Assert.Equal(1, inScope);
	}

	[Fact]
	public async Task InitializeAndDisposeActionsWithEarlyExit()
	{
		int inScope = 0;
		await using (var scope = new AsyncDisposeScopeExit(() => ++inScope, () => { --inScope; return Task.CompletedTask; }))
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
	public async Task InitializeAndDisposeActionsWithEarlyDispose()
	{
		int inScope = 0;
		await using (var scope = new AsyncDisposeScopeExit(() => ++inScope, () => { --inScope; return Task.CompletedTask; }))
		{
			Assert.Equal(1, inScope);
			++inScope;
			Assert.Equal(2, inScope);

			await scope.DisposeAsync();
			Assert.Equal(1, inScope);
		}
		Assert.Equal(1, inScope);
	}
}
