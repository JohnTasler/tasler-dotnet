using System;

namespace Tasler.Windows.Forms
{
	/// <summary>
	/// Summary description for IWizardFrame.
	/// </summary>
	public interface IWizardFrame 
	{
		#region Properties
		int PageCount { get; }
		IWizardPage ActivePage { get; }
		bool BackButtonEnabled { get; set; }
		bool BackButtonVisible { get; set; }
		bool NextButtonEnabled { get; set; }
		bool NextButtonVisible { get; set; }
		bool FinishButtonEnabled { get; set; }
		bool FinishButtonVisible { get; set; }
		#endregion

		#region Methods
		void AddPage(IWizardPage page);
		void InsertPage(IWizardPage insertAfter, IWizardPage page);
		void PressBackButton();
		void PressNextButton();
		void PressFinishButton();
		void PressCancelButton();
		#endregion
	}
}
