using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Regions;

namespace Tasler.Practices.Prism.Regions
{
	public class RegionNavigationJournal : IRegionNavigationJournal, IMultiStepRegionNavigationJournal
	{
		#region Instance Fields
		private readonly Stack<IRegionNavigationJournalEntry> backStack = new Stack<IRegionNavigationJournalEntry>();
		private readonly Stack<IRegionNavigationJournalEntry> forwardStack = new Stack<IRegionNavigationJournalEntry>();
		private bool isNavigatingInternal;
		#endregion Instance Fields

		#region Properties
		public IEnumerable<IRegionNavigationJournalEntry> BackStack
		{
			get { return from entry in this.backStack select entry; }
		}

		public IEnumerable<IRegionNavigationJournalEntry> ForwardStack
		{
			get { return from entry in this.forwardStack select entry; }
		}
		#endregion Properties

		#region Methods
		public bool CanGoStepsBack(int numberOfSteps)
		{
			if (numberOfSteps <= 0)
				throw new ArgumentOutOfRangeException("numberOfSteps");

			return this.backStack.Count >= numberOfSteps;
		}

		public bool CanGoStepsForward(int numberOfSteps)
		{
			if (numberOfSteps <= 0)
				throw new ArgumentOutOfRangeException("numberOfSteps");

			return this.forwardStack.Count >= numberOfSteps;
		}

		public void GoStepsBack(int numberOfSteps)
		{
			if (this.CanGoStepsBack(numberOfSteps))
			{
				// Peek at the entry at the specified number of steps off the stack
				var entry = this.backStack.ElementAt(numberOfSteps - 1);
				this.InternalNavigate(entry, result =>
				{
					if (result)
					{
						if (CurrentEntry != null)
							this.forwardStack.Push(this.CurrentEntry);

						this.backStack.Pop();

						for (var i = 1; i < numberOfSteps; ++i)
							this.forwardStack.Push(this.backStack.Pop());

						this.CurrentEntry = entry;
					}
				});
			}
		}

		public void GoStepsForward(int numberOfSteps)
		{
			if (this.CanGoForward)
			{
				// Peek at the entry at the specified number of steps off the stack
				var entry = this.forwardStack.ElementAt(numberOfSteps - 1);
				this.InternalNavigate(entry, result =>
				{
					if (result)
					{
						if (this.CurrentEntry != null)
							this.backStack.Push(this.CurrentEntry);

						this.forwardStack.Pop();

						for (var i = 1; i < numberOfSteps; ++i)
							this.backStack.Push(this.forwardStack.Pop());

						this.CurrentEntry = entry;
					}
				});
			}
		}
		#endregion Methods

		#region IRegionNavigationJournal Members
		public IRegionNavigationJournalEntry CurrentEntry { get; private set; }

		public INavigateAsync NavigationTarget { get; set; }

		public bool CanGoBack
		{
			get { return this.CanGoStepsBack(1); }
		}

		public bool CanGoForward
		{
			get { return this.CanGoStepsForward(1); }
		}

		public void Clear()
		{
			this.CurrentEntry = null;
			this.backStack.Clear();
			this.forwardStack.Clear();
		}

		public void GoBack()
		{
			this.GoStepsBack(1);
		}

		public void GoForward()
		{
			this.GoStepsForward(1);
		}

		public void RecordNavigation(IRegionNavigationJournalEntry entry)
		{
			if (!this.isNavigatingInternal)
			{
				if (this.CurrentEntry != null)
					this.backStack.Push(this.CurrentEntry);

				this.forwardStack.Clear();
				this.CurrentEntry = entry;
			}
		}
		#endregion IRegionNavigationJournal Members

		#region Private Implementation
		private void InternalNavigate(IRegionNavigationJournalEntry entry, Action<bool> callback)
		{
			this.isNavigatingInternal = true;
			this.NavigationTarget.RequestNavigate(entry.Uri, nr =>
			{
				this.isNavigatingInternal = false;
				if (nr.Result.HasValue)
					callback(nr.Result.Value);
			});
		}
		#endregion Private Implementation
	}
}
