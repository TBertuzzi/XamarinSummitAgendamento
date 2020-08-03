using System;
using System.Collections.Generic;
using System.Globalization;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Plugin.Calendar.Models;
using XamarinSummitAgendamento.Models;
using XamarinSummitAgendamento.Services;

namespace XamarinSummitAgendamento.ViewModels
{
    public class AgendaPageViewModel : ViewModelBase
    {
        private IAgendamentosService _agendamentosService;
        //public EventCollection Events { get; set; }
        private CultureInfo _culture = CultureInfo.InvariantCulture;
        public CultureInfo Culture
        {
            get => _culture;
            set => SetProperty(ref _culture, value);
        }

        private EventCollection _events = new EventCollection();
        public EventCollection Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }

        protected AgendaPageViewModel(INavigationService navigationService,
            IPageDialogService pageDialogService, IAgendamentosService agendamentosService) : base(navigationService, pageDialogService)
        {

            IsActiveChanged += HandleIsActiveTrue;
            IsActiveChanged += HandleIsActiveFalse;

            _agendamentosService = agendamentosService;

        }

        private void HandleIsActiveTrue(object sender, EventArgs args)
        {
            if (IsActive == false) return;

            CarregarEventos();

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

        private void CarregarEventos()
        {
            Culture = CultureInfo.CreateSpecificCulture("pt-BR");

            Events.Clear();

            var agendamentos = _agendamentosService.ObterAgendamentos();
            int cont = 1;

            foreach (var agendamento in agendamentos)
            {
                Events.Add(agendamento.DataHora,
                    new List<Agendamento> { agendamento });

                cont++;
            }

        }
    }
}
