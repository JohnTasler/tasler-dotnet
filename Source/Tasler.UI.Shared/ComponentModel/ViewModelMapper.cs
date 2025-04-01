using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Extensions.Hosting;

namespace Tasler.ComponentModel;

public interface IViewModelMapper
{
	void AddMapping(Type viewModel, Type view);

	Type GetViewTypeForViewModelType(Type viewModel);
}

public interface IPopulateViewModelMapper
{
	static abstract void Populate(IViewModelMapper mapper);
}

public class ViewModelMapper : IViewModelMapper
{
	private readonly Dictionary<Type, Type> _mappings = [];

	public void AddMapping(Type viewModel, Type view)
	{
		_mappings.Add(viewModel, view);
	}

	public Type GetViewTypeForViewModelType(Type viewModel)
	{
		return _mappings[viewModel];
	}
}
