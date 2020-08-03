using System;
using System.Collections.ObjectModel;
using Prism.Navigation;
using Prism.Services;
using XamarinSummitAgendamento.Models;
using XamarinSummitAgendamento.Services;

namespace XamarinSummitAgendamento.ViewModels
{
    public class AgendamentosPageViewModel : ViewModelBase
    {
        private IAgendamentosService _agendamentosService;
        public ObservableCollection<Agendamento> Agendamentos { get; }
        protected AgendamentosPageViewModel(INavigationService navigationService,
             IPageDialogService pageDialogService, IAgendamentosService agendamentosService) : base(navigationService, pageDialogService)
        {
            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;

            _agendamentosService = agendamentosService;

            Agendamentos = new ObservableCollection<Agendamento>();
        }

        private void HandleIsActiveTrue(object sender, EventArgs args)
        {
            if (IsActive == false) return;

            CarregarEAgendamentos();

        }

        private void HandleIsActiveFalse(object sender, EventArgs args)
        {
            if (IsActive == true) return;
        }

        public override void Destroy()
        {
            IsActiveChanged -= HandleIsActiveTrue;
            IsActiveChanged -= HandleIsActiveFalse;
        }

        private void CarregarEAgendamentos()
        {
            try
            {
         
                IsBusy = true;
                var agendamentos = _agendamentosService.ObterAgendamentos();

                Agendamentos.Clear();


                foreach (var agendamento in agendamentos)
                {
                    Agendamentos.Add(agendamento);
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
