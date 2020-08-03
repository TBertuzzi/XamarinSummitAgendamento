using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Plugin.LocalNotification;
using Prism.Commands;
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

        private DelegateCommand _confirmarCommand;
        public DelegateCommand ConfirmarCommand => _confirmarCommand ?? (_confirmarCommand = new DelegateCommand(async () => await ConfirmarCommandExecute(), () => !IsBusy));

        private DelegateCommand _lembrarCommand;
        public DelegateCommand LembrarCommand => _lembrarCommand ?? (_lembrarCommand = new DelegateCommand( () => LembrarCommandExecute(), () => !IsBusy));


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

        private async Task ConfirmarCommandExecute()
        {
            var request = new AuthenticationRequestConfiguration("Confirme seu Exame", "Apenas o proprietario pode confirmar os exames");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (result.Authenticated)
            {
                await PageDialogService.DisplayAlertAsync("Confirmado", "Exame confirmado", "OK");
            }
            else
            {
                await PageDialogService.DisplayAlertAsync("Nao Confirmado", "Apenas o proprietario pode confirmar os exames", "OK");
            }
        }

        //Agenda um Exame para 10 Segundos
        private void LembrarCommandExecute()
        {
            var notification = new NotificationRequest
            {
                NotificationId = 100,
                Title = "Lembrete de Exame",
                Description = "Seu Exame Começara em Breve",
                ReturningData = "Exame Solicitado",
                NotifyTime = DateTime.Now.AddSeconds(10)
            };
            NotificationCenter.Current.Show(notification);
        }

    }
}
