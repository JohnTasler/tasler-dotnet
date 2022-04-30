﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using Tasler.Interop.RawInput.User;
using Tasler.Interop.User;

namespace Tasler.Windows.Input
{
	public class HumanInputBinding : InputBinding, ISupportInitialize
	{
		#region Static Fields
		private static int messageHooked;
		#endregion Static Fields

		#region Instance Fields
		private bool initPending;
		private HumanInputBindingMode mode;
		#endregion Instance Fields

		#region Construction
		public HumanInputBinding()
		{
		}

		public HumanInputBinding(ICommand command, HumanInputGesture gesture)
			: base(command, gesture)
		{
		}
		#endregion Construction

		#region Properties
		public override InputGesture Gesture
		{
			get
			{
				return base.Gesture;
			}
			set
			{
				HumanInputGesture gesture = value as HumanInputGesture;
				if (gesture == null)
					throw new ArgumentException("HumanInputBinding only accepts HumanInputGesture.");

				this.CheckInitialization();

				base.Gesture = gesture;
			}
		}

		public HumanInputBindingMode Mode
		{
			get
			{
				return this.mode;
			}
			set
			{
				this.CheckInitialization();
				this.mode = value;
			}
		}
		#endregion Properties

		#region Dependency Properties

		#region Element

		public static DependencyProperty ElementProperty =
			DependencyProperty.Register("Element", typeof(DependencyObject), typeof(HumanInputBinding),
				new PropertyMetadata());

		private void ElementPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var instance = (HumanInputBinding)d;
			instance.CheckInitialization();
		}

		public DependencyObject Element
		{
			get { return (DependencyObject)base.GetValue(HumanInputBinding.ElementProperty); }
			set { base.SetValue(HumanInputBinding.ElementProperty, value); }
		}

		#endregion Element

		#endregion Dependency Properties

		#region ISupportInitialize Members

		/// <summary>
		/// Starts the initialization process for this input binding. 
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">
		/// Called <see cref="M:HumanInputBinding.BeginInit" /> more than once before <see cref="M:HumanInputBinding.EndInit" /> was called.
		/// </exception>
		public void BeginInit()
		{
			if (this.initPending)
				throw new InvalidOperationException(Properties.Resources.NestedBeginInitNotSupported);

			// Set the flag to indicate that initialization is pending
			this.initPending = true;
		}

		/// <summary>
		/// Indicates that the initialization process for the input binding is complete. 
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">
		/// <see cref="M:HumanInputBinding.EndInit" /> was called without <see cref="M:HumanInputBinding.BeginInit" /> having previously been called on the input binding.
		/// </exception>
		public void EndInit()
		{
			if (!this.initPending)
				throw new InvalidOperationException(Properties.Resources.EndInitWithoutBeginInitNotSupported);

			this.RegisterInputBinding();

			// Reset the flag to indicate that initialization is complete
			this.initPending = false;
		}

		#endregion ISupportInitialize Members

		#region Private Implementation
		private void CheckInitialization()
		{
			if (!this.initPending)
				throw new InvalidOperationException(Properties.Resources.NotInInitialization);
		}

		private static RegistrationFlags FlagFromMode(HumanInputBindingMode mode)
		{
			switch (mode)
			{
				case HumanInputBindingMode.BackgroundAlways:
					return RegistrationFlags.InputSink;

				case HumanInputBindingMode.BackgroundIfUnhandled:
					return RegistrationFlags.ExInputSink;

				case HumanInputBindingMode.Focused:
				default:
					return RegistrationFlags.Default;
			}
		}

		private void RegisterInputBinding()
		{
			HumanInputGesture gesture = this.Gesture as HumanInputGesture;
			if (gesture == null)
				throw new ArgumentException("HumanInputBinding.Gesture must be set to a non-null HumanInputGesture.");

			// Get the Window containing the Element property, if any
			var element = this.Element;
			Window window = element != null ? Window.GetWindow(element) : null;

			// Get the RegistrationFlags from the Mode property
			RegistrationFlags flags = FlagFromMode(this.Mode);

			// Validate that the background modes are specified with an Element
			if (flags != RegistrationFlags.Default && window == null)
				throw new InvalidOperationException("TODO: TODO: TODO:");

			// Determine if the Window has its PresentationSource yet
			var source = window != null ? (HwndSource)HwndSource.FromVisual(window) : null;

			// If the Window is not null but has no PresentationSource yet, don't register until it has
			if (window != null && source == null)
			{
				EventHandler windowSourceInitialized = null;
				windowSourceInitialized = (sender, args) =>
				{
					window.SourceInitialized -= windowSourceInitialized;
					this.RegisterInputBinding();
				};

				window.SourceInitialized += windowSourceInitialized;
			}
			else
			{
				var devices = new RAWINPUTDEVICE[1];
				devices[0] = new RAWINPUTDEVICE()
				{
					Usage = gesture.Usage,
					UsagePage = gesture.UsagePage,
					WindowHandle = source != null ? source.Handle : IntPtr.Zero,
					Flags = flags,
				};
				bool succeeded = RawInputApi.RegisterRawInputDevices(
					devices, devices.Length, Marshal.SizeOf(typeof(RAWINPUTDEVICE)));

				if (Interlocked.Increment(ref HumanInputBinding.messageHooked) == 1)
					ComponentDispatcher.ThreadPreprocessMessage += HumanInputBinding.ComponentDispatcher_ThreadPreprocessMessage;
			}
		}

		private static void ComponentDispatcher_ThreadPreprocessMessage(ref MSG msg, ref bool handled)
		{
			if (msg.message == (int)WM.INPUT)
			{
				HumanInputEventArgs args = HumanInputEventArgs.FromRawInput(msg.lParam);
				args.RoutedEvent = Keyboard.PreviewKeyDownEvent;
				Keyboard.FocusedElement.RaiseEvent(args);
				if (!args.Handled)
				{
					args.RoutedEvent = Keyboard.KeyDownEvent;
					Keyboard.FocusedElement.RaiseEvent(args);
				}

				handled = args.Handled;
			}
		}
		#endregion Private Implementation
	}

	public enum HumanInputBindingMode
	{
		/// <summary>
		/// The application receives raw input from devices matching the <see cref="T:HumanInputGesture"/>, specified
		/// in the <see cref="M:HumanInputBinding.Gesture"/>, as long as the application has the window focus.
		/// </summary>
		Focused,

		/// <summary>
		/// The <see cref="T:Window"/> containing the <see cref="M:HumanInputBinding.Element"/> receives raw input from
		/// devices matching the <see cref="T:HumanInputGesture"/>, specified in the
		/// <see cref="M:HumanInputBinding.Gesture"/> property, even when the window is not in the foreground. Note that
		/// the <see cref="M:HumanInputBinding.Element"/> property must specify a non-null <see cref="T:DependencyObject"/>
		/// contained within the tree of a <see cref="T:Window"/>.
		/// </summary>
		BackgroundAlways,

		/// <summary>
		/// The <see cref="T:Window"/> containing the <see cref="M:HumanInputBinding.Element"/> receives raw input from
		/// devices matching the <see cref="T:HumanInputGesture"/>, specified in the
		/// <see cref="M:HumanInputBinding.Gesture"/> property, even when the window is not in the foreground, but only if
		/// the foreground window does not process it. Note that the <see cref="M:HumanInputBinding.Element"/> property
		/// must specify a non-null <see cref="T:DependencyObject"/> contained within tree of a <see cref="T:Window"/>.
		/// </summary>
		BackgroundIfUnhandled,
	}
}
