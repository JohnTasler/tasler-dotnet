using System;
using System.Windows.Forms;

namespace Tasler.Windows.Forms 
{
	/// <summary>
	/// Summary description for WizardPage.
	/// </summary>
	public class WizardPage : System.Windows.Forms.UserControl, IWizardPage 
	{
		#region Instance Fields
		private IWizardFrame wizardFrame;
		#endregion

		#region Construction 
		public WizardPage()
		{
		}
		#endregion

		#region IWizardPage Members
		public virtual IWizardFrame WizardFrame 
		{
			get { return this.wizardFrame; }
			set { this.wizardFrame = value; }
		}
		public virtual IWizardPage OnDeactivating(IWizardPage pageActivating, bool movingForward) 
		{
			return null;
		}

		public virtual void OnActivating(IWizardPage pageDeactivating, bool movingForward) 
		{
		}
		#endregion
	}

	public interface IWizardPage 
	{
		#region Properties
		IWizardFrame WizardFrame { get; set; }
		#endregion

		#region Methods
		IWizardPage OnDeactivating(IWizardPage pageActivating, bool movingForward);
		void OnActivating(IWizardPage pageDeactivating, bool movingForward);
		#endregion
	}
}
