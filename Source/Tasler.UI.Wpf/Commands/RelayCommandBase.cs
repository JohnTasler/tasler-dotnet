//======================================================================================
// Copied from Prism 4.1.0.0.
// Namespace renamed from Microsoft.Practices.Prism.Commands to Tasler.Windows.Commands.
// Class renamed from DelegateCommandBase to RelayCommandBase.
//
// This allows the library components to provide delagate-based ICommand implementations
// without taking a dependency on the Prism library.
//======================================================================================

//===================================================================================
// Microsoft patterns & practices
// Composite Application Guidance for Windows Presentation Foundation and Silverlight
//===================================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===================================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===================================================================================
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Tasler.Windows.Properties;

namespace Tasler.Windows.Commands
{
	/// <summary>
	/// An <see cref="ICommand"/> whose delegates can be attached for <see cref="Execute"/> and <see cref="CanExecute"/>.
	/// It also implements the <see cref="IActiveAware"/> interface, which is
	/// useful when registering this command in a <see cref="CompositeCommand"/>
	/// that monitors command's activity.
	/// </summary>
	public abstract class RelayCommandBase : ICommand
	{
		private readonly Action<object> executeMethod;
		private readonly Func<object, bool> canExecuteMethod;

#if !SILVERLIGHT
		private List<WeakReference> canExecuteChangedHandlers;
#endif

		/// <summary>
		/// Createse a new instance of a <see cref="RelayCommandBase"/>, specifying both the execute action and the can execute function.
		/// </summary>
		/// <param name="executeMethod">The <see cref="Action"/> to execute when <see cref="ICommand.Execute"/> is invoked.</param>
		/// <param name="canExecuteMethod">The <see cref="Func{Object,Bool}"/> to invoked when <see cref="ICommand.CanExecute"/> is invoked.</param>
		protected RelayCommandBase(Action<object> executeMethod, Func<object, bool> canExecuteMethod)
		{
			if (executeMethod == null || canExecuteMethod == null)
				throw new ArgumentNullException("executeMethod", Resources.RelayCommandDelegatesCannotBeNull);

			this.executeMethod = executeMethod;
			this.canExecuteMethod = canExecuteMethod;
		}

#if SILVERLIGHT
		/// <summary>
		/// Raises <see cref="ICommand.CanExecuteChanged"/> on the UI thread so every 
		/// command invoker can requery <see cref="ICommand.CanExecute"/> to check if the
		/// <see cref="CompositeCommand"/> can execute.
		/// </summary>
		protected virtual void OnCanExecuteChanged()
		{
			var handlers = CanExecuteChanged;
			if (handlers != null)
			{
				handlers(this, EventArgs.Empty);
			}
		}
#else

		/// <summary>
		/// Raises <see cref="ICommand.CanExecuteChanged"/> on the UI thread so every 
		/// command invoker can requery <see cref="ICommand.CanExecute"/> to check if the
		/// <see cref="CompositeCommand"/> can execute.
		/// </summary>
		protected virtual void OnCanExecuteChanged()
		{
			WeakEventHandlerManager.CallWeakReferenceHandlers(this, canExecuteChangedHandlers);
		}
#endif

		/// <summary>
		/// Raises <see cref="RelayCommandBase.CanExecuteChanged"/> on the UI thread so every command invoker
		/// can requery to check if the command can execute.
		/// <remarks>Note that this will trigger the execution of <see cref="RelayCommandBase.CanExecute"/> once for each invoker.</remarks>
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate")]
		public void RaiseCanExecuteChanged()
		{
			OnCanExecuteChanged();
		}

		void ICommand.Execute(object parameter)
		{
			Execute(parameter);
		}

		bool ICommand.CanExecute(object parameter)
		{
			return CanExecute(parameter);
		}

		/// <summary>
		/// Executes the command with the provided parameter by invoking the <see cref="Action{Object}"/> supplied during construction.
		/// </summary>
		/// <param name="parameter"></param>
		protected void Execute(object parameter)
		{
			executeMethod(parameter);
		}

		/// <summary>
		/// Determines if the command can execute with the provided parameter by invoing the <see cref="Func{Object,Bool}"/> supplied during construction.
		/// </summary>
		/// <param name="parameter">The parameter to use when determining if this command can execute.</param>
		/// <returns>Returns <see langword="true"/> if the command can execute.  <see langword="False"/> otherwise.</returns>
		protected bool CanExecute(object parameter)
		{
			return canExecuteMethod == null || canExecuteMethod(parameter);
		}

#if SILVERLIGHT
		/// <summary>
		/// Occurs when changes occur that affect whether or not the command should execute. 
		/// </summary>
			public event EventHandler CanExecuteChanged;
#else
		/// <summary>
		/// Occurs when changes occur that affect whether or not the command should execute. You must keep a hard
		/// reference to the handler to avoid garbage collection and unexpected results. See remarks for more information.
		/// </summary>
		/// <remarks>
		/// When subscribing to the <see cref="ICommand.CanExecuteChanged"/> event using 
		/// code (not when binding using XAML) will need to keep a hard reference to the event handler. This is to prevent 
		/// garbage collection of the event handler because the command implements the Weak Event pattern so it does not have
		/// a hard reference to this handler. An example implementation can be seen in the CompositeCommand and CommandBehaviorBase
		/// classes. In most scenarios, there is no reason to sign up to the CanExecuteChanged event directly, but if you do, you
		/// are responsible for maintaining the reference.
		/// </remarks>
		/// <example>
		/// The following code holds a reference to the event handler. The myEventHandlerReference value should be stored
		/// in an instance member to avoid it from being garbage collected.
		/// <code>
		/// EventHandler myEventHandlerReference = new EventHandler(this.OnCanExecuteChanged);
		/// command.CanExecuteChanged += myEventHandlerReference;
		/// </code>
		/// </example>
		public event EventHandler CanExecuteChanged
		{
			add
			{
				WeakEventHandlerManager.AddWeakReferenceHandler(ref canExecuteChangedHandlers, value, 2);
			}
			remove
			{
				WeakEventHandlerManager.RemoveWeakReferenceHandler(canExecuteChangedHandlers, value);
			}
		}
#endif
	}
}