using System;
using Prism.Navigation;
using Prism.Services;

namespace XamarinSummitAgendamento.ViewModels
{
    public class AgendamentosPageViewModel : ViewModelBase
    {
        protected AgendamentosPageViewModel(INavigationService navigationService,
             IPageDialogService pageDialogService) : base(navigationService, pageDialogService)
        {

        }
    }
}
