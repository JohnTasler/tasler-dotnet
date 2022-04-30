using System.Collections.Generic;
using Microsoft.Practices.Prism.Regions;

namespace Tasler.Practices.Prism.Regions
{
	public interface IMultiStepRegionNavigationJournal
	{
		IEnumerable<IRegionNavigationJournalEntry> BackStack { get; }

		IEnumerable<IRegionNavigationJournalEntry> ForwardStack { get; }

		bool CanGoStepsBack(int numberOfSteps);

		bool CanGoStepsForward(int numberOfSteps);

		void GoStepsBack(int numberOfSteps);

		void GoStepsForward(int numberOfSteps);
	}
}
