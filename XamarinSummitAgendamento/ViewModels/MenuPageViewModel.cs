using System;
using Prism.Navigation;
using Prism.Services;

namespace XamarinSummitAgendamento.ViewModels
{
    public class MenuPageViewModel : ViewModelBase
    {

        protected MenuPageViewModel(INavigationService navigationService,
           IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }

    }
}
