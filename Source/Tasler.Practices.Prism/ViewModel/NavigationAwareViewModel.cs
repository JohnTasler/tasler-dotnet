using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Tasler.ComponentModel;
using Tasler.Practices.Prism.Extensions;
using Tasler.Practices.Prism.Regions;
using Tasler.Windows.ComponentModel;

namespace Tasler.Practices.Prism
{
	public abstract class NavigationAwareViewModel : ViewModelBase, INavigationAware
	{
		#region Properties
		public IRegionManager RegionManager
		{
			get
			{
				var result = this.regionManager;

				if (result == null && this.NavigationService != null)
					result = this.NavigationService.Region.RegionManager;

				if (result == null)
					result = ServiceLocator.Current.GetInstance<IRegionManager>();

				return result;
			}
			protected set { this.regionManager = value; }
		}
		private IRegionManager regionManager;

		protected IRegionNavigationService NavigationService
		{
			get { return this.navigationService; }
			private set
			{
				if (this.SetProperty(ref this.navigationService, value, () => NavigationService, () => RegionManager))
				{
					this.multiStepNavigationService = value as IMultiStepRegionNavigationJournal;

					DelegateCommandExtensions.RaiseCanExecuteChanged(
						this.navigateBackCommand, this.navigateForwardCommand,
						this.navigateStepsBackCommand, this.navigateStepsForwardCommand);
				}
			}
		}
		private IRegionNavigationService navigationService;
		private IMultiStepRegionNavigationJournal multiStepNavigationService;
		#endregion Properties

		#region Commands

		#region NavigateBackCommand
		public ICommand NavigateBackCommand
		{
			get
			{
				return this.navigateBackCommand ??
					(this.navigateBackCommand = new DelegateCommand(this.NavigateBack, this.CanNavigateBack));
			}
		}
		private DelegateCommand navigateBackCommand;

		private bool CanNavigateBack()
		{
			return this.NavigationService != null && this.NavigationService.Journal.CanGoBack;
		}

		private void NavigateBack()
		{
			this.NavigationService.Journal.GoBack();
		}
		#endregion NavigateBackCommand

		#region NavigateForwardCommand
		public ICommand NavigateForwardCommand
		{
			get
			{
				return this.navigateForwardCommand ??
					(this.navigateForwardCommand = new DelegateCommand(this.NavigateForward, this.CanNavigateForward));
			}
		}
		private DelegateCommand navigateForwardCommand;

		private bool CanNavigateForward()
		{
			return this.NavigationService != null && this.NavigationService.Journal.CanGoForward;
		}

		private void NavigateForward()
		{
			this.NavigationService.Journal.GoForward();
		}
		#endregion NavigateForwardCommand

		#region NavigateStepsBackCommand
		public ICommand NavigateStepsBackCommand
		{
			get
			{
				return this.navigateStepsBackCommand ??
					(this.navigateStepsBackCommand = new DelegateCommand<int?>(this.NavigateStepsBack, this.CanNavigateStepsBack));
			}
		}
		private DelegateCommand<int?> navigateStepsBackCommand;

		private bool CanNavigateStepsBack(int? param)
		{
			if (param == null || param.Value == 1)
				return this.CanNavigateBack();

			if (this.multiStepNavigationService != null)
				this.multiStepNavigationService.CanGoStepsBack(param.Value);

			return false;
		}

		private void NavigateStepsBack(int? param)
		{
			if (param == null || param.Value == 1)
				this.NavigateBack();

			if (this.multiStepNavigationService != null)
				this.multiStepNavigationService.GoStepsBack(param.Value);
		}
		#endregion NavigateStepsBackCommand

		#region NavigateStepsForwardCommand
		public ICommand NavigateStepsForwardCommand
		{
			get
			{
				return this.navigateStepsForwardCommand ??
					(this.navigateStepsForwardCommand = new DelegateCommand<int?>(this.NavigateStepsForward, this.CanNavigateStepsForward));
			}
		}
		private DelegateCommand<int?> navigateStepsForwardCommand;

		private bool CanNavigateStepsForward(int? param)
		{
			if (param == null || param.Value == 1)
				return this.CanNavigateForward();

			if (this.multiStepNavigationService != null)
				this.multiStepNavigationService.CanGoStepsForward(param.Value);

			return false;
		}

		private void NavigateStepsForward(int? param)
		{
			if (param == null || param.Value == 1)
				this.NavigateForward();

			if (this.multiStepNavigationService != null)
				this.multiStepNavigationService.GoStepsForward(param.Value);
		}
		#endregion NavigateStepsForwardCommand

		#endregion Commands

		#region Overridables

		protected virtual bool IsNavigationTarget()
		{
			return true;
		}

		protected virtual void OnNavigatedFrom()
		{
		}

		protected virtual void OnNavigatedTo()
		{
		}

		#endregion Overridables

		#region INavigationAware Members

		//bool INavigationAware.IsNavigationTarget(NavigationContext navigationContext)
		public bool IsNavigationTarget(NavigationContext navigationContext)
		{
			this.NavigationService = navigationContext.NavigationService;
			return this.IsNavigationTarget();
		}

		//void INavigationAware.OnNavigatedFrom(NavigationContext navigationContext)
		public void OnNavigatedFrom(NavigationContext navigationContext)
		{
			this.NavigationService = navigationContext.NavigationService;
			this.OnNavigatedFrom();
		}

		//void INavigationAware.OnNavigatedTo(NavigationContext navigationContext)
		public void OnNavigatedTo(NavigationContext navigationContext)
		{
			this.NavigationService = navigationContext.NavigationService;
			this.OnNavigatedTo();
		}

		#endregion INavigationAware Members
	}
}
