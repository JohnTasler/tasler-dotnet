using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Tasler.Windows.Extensions;

namespace Tasler.Windows.Attachments
{
	public static class InputBindingService
	{
		#region InputElement
		public static readonly DependencyProperty InputElementProperty =
			DependencyProperty.RegisterAttached("InputElement", typeof(UIElement), typeof(InputBindingService),
				new PropertyMetadata(null, InputElementPropertyChanged));

		public static UIElement GetInputElement(FrameworkElement d)
		{
			return (UIElement)d.GetValue(InputElementProperty);
		}

		public static void SetInputElement(FrameworkElement d, UIElement value)
		{
			d.SetValue(InputElementProperty, value);
		}

		private static void InputElementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			// Do nothing if invalid
			var element = d as FrameworkElement;
			if (element == null)
				return;

			// Do nothing when in design mode
			if (DesignerProperties.GetIsInDesignMode(element))
				return;

			var oldValue = (UIElement)e.OldValue;
			var newValue = (UIElement)e.NewValue;

			if (element.IsLoaded)
				InputElementPropertyChanged(element, oldValue, newValue);

			RoutedEventHandler elementLoadedHandler = (sender, args) =>
				InputElementPropertyChanged(element, oldValue, newValue);

			RoutedEventHandler elementUnloadedHandler = (sender, args) =>
				InputElementPropertyChanged(element, null, null);

			if (newValue != null)
			{
				element.Loaded += elementLoadedHandler;
				element.Unloaded += elementUnloadedHandler;
			}
			else
			{
				element.Loaded -= elementLoadedHandler;
				element.Unloaded -= elementUnloadedHandler;
			}
		}

		private static void InputElementPropertyChanged(FrameworkElement element, UIElement oldValue, UIElement newValue)
		{
			// Get the dictionary of inputBindings to clones we have in the Window's input bindings
			var clones = GetClones(element);

			// Get the element's collection of input bindings
			var inputBindings = element.InputBindings.OfType<InputBinding>();

			EventHandler inputBindingChangedHandler =
				(sender, unused) => UpdateInputBinding(element, newValue, sender as InputBinding);

			if (newValue != null)
			{
				// The dictionary of clones should currently be empty
				Debug.Assert(clones.Count == 0);
				clones.Clear();

				// Clone each input binding, and add the clone both to our dictionary and the inputElement's collection
				foreach (var inputBinding in inputBindings)
				{
					UpdateInputBinding(element, newValue, inputBinding);

					// Subscribe to property changes on the input binding
					inputBinding.Changed += inputBindingChangedHandler;

					// Subscribe to changes on the input binding's command
					if (inputBinding.Command != null)
					{
						UpdateInputBindingCommandCanExecuteChanged(element, inputBinding);
						EventHandler canExecuteChangedHandler = (s, e) => UpdateInputBindingCommandCanExecuteChanged(element, inputBinding);
						inputBinding.Command.CanExecuteChanged += canExecuteChangedHandler;
						AddToReferenceCache(element, canExecuteChangedHandler);
					}
				}
			}
			else
			{
				// Cleanup each input binding and its clone
				foreach (var inputBinding in inputBindings)
				{
					// Unsubscribe from changes on the input binding's command
					if (inputBinding.Command != null)
					{
						EventHandler canExecuteChangedHandler = (s, e) => UpdateInputBindingCommandCanExecuteChanged(element, inputBinding);
						inputBinding.Command.CanExecuteChanged -= canExecuteChangedHandler;
						RemoveFromReferenceCache(element, canExecuteChangedHandler);
					}

					// Unsubscribe from property changes on the input binding
					if (element.IsLoaded)
						inputBinding.Changed -= inputBindingChangedHandler;

					// Remove the clone we made of the input binding from the input element's collection
					if (oldValue != null)
					{
						InputBinding clone;
						if (clones.TryGetValue(inputBinding, out clone))
							oldValue.InputBindings.Remove(clone);
					}

					// Remove the input binding from our dictionary
					clones.Remove(inputBinding);
				}

				// Ensure the dictionary of clones is empty
				Debug.Assert(clones.Count == 0);
				clones.Clear();
			}
		}

		#endregion InputElement

		#region Clones
		private static readonly DependencyProperty ClonesProperty =
			DependencyProperty.RegisterAttached("Clones", typeof(Dictionary<InputBinding, InputBinding>),
				typeof(InputBindingService), new PropertyMetadata(null));

		private static Dictionary<InputBinding, InputBinding> GetClones(FrameworkElement d)
		{
			var result = (Dictionary<InputBinding, InputBinding>)d.GetValue(ClonesProperty);
			if (result == null)
				d.SetValue(ClonesProperty, result = new Dictionary<InputBinding, InputBinding>(d.InputBindings.Count));

			return result;
		}
		#endregion Clones

		#region ReferenceCache
			private static readonly DependencyProperty ReferenceCacheProperty =
			DependencyProperty.RegisterAttached("ReferenceCache", typeof(HashSet<object>),
				typeof(InputBindingService), new PropertyMetadata(null));

		private static HashSet<object> GetReferenceCache(FrameworkElement d)
		{
			var result = (HashSet<object>)d.GetValue(ReferenceCacheProperty);
			if (result == null)
				d.SetValue(ReferenceCacheProperty, result = new HashSet<object>(new object[d.InputBindings.Count]));

			return result;
		}

		private static void AddToReferenceCache(FrameworkElement d, object reference)
		{
			GetReferenceCache(d).Add(reference);
		}

		private static void RemoveFromReferenceCache(FrameworkElement d, object reference)
		{
			var cache = (HashSet<object>)d.GetValue(ReferenceCacheProperty);
			if (cache != null)
				cache.Remove(reference);
		}
		#endregion ReferenceCache

		#region Private Implementation

		private static InputBinding CloneInputBinding(InputBinding inputBinding)
		{
			// Create the cloned object
			var clone = (InputBinding)inputBinding.Clone();

			// Copy the dependency property values from the specified inputBinding to the clone
			var enumerator = inputBinding.GetLocalValueEnumerator();
			while (enumerator.MoveNext())
			{
				var entry = enumerator.Current;
				clone.SetValue(entry.Property, inputBinding.GetValue(entry.Property));
			}

			return clone;
		}

		private static void UpdateInputBinding(FrameworkElement element, UIElement inputElement, InputBinding inputBinding)
		{
			// Do nothing if invalid
			if (inputBinding == null || inputElement == null)
				return;

			// Get the dictionary of inputBindings to clones we have in the Window's input bindings
			var clones = GetClones(element);

			// Remove the existing clone from the window's input bindings
			InputBinding clone;
			if (clones.TryGetValue(inputBinding, out clone))
				inputElement.InputBindings.Remove(clone);

			// Create a new clone of the specified input binding
			clone = CloneInputBinding(inputBinding);

			// Replace the clone associated with the specified input binding
			clones[inputBinding] = clone;

			// Add the new clone to the window's input bindings
			inputElement.InputBindings.Add(clone);
		}

		private static void UpdateInputBindingCommandCanExecuteChanged(FrameworkElement element, InputBinding inputBinding)
		{
			if (inputBinding.Command != null)
			{
				// Get the dictionary of inputBindings to clones we have in the input element's input bindings
				var clones = GetClones(element);

				// Change the clone's Command to null if the input binding's command cannot currently execute
				InputBinding clone;
				if (clones.TryGetValue(inputBinding, out clone))
					clone.Command = inputBinding.CanExecuteCommandSource() ? inputBinding.Command : null;
			}
		}

		#endregion Private Implementation
	}
}