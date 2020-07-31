using System;
using Prism.Navigation;
using Prism.Services;

namespace XamarinSummitAgendamento.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        protected MainPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }
    }
}
