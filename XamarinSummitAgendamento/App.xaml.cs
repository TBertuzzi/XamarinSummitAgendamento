using System;
using System.Collections.Generic;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSummitAgendamento.Controles;
using XamarinSummitAgendamento.Models;
using XamarinSummitAgendamento.Repository;
using XamarinSummitAgendamento.Services;
using XamarinSummitAgendamento.ViewModels;

namespace XamarinSummitAgendamento
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            FakeDBAgendamento.Agendamentos = new List<Agendamento>();

            XF.Material.Forms.Material.Init(this, "Material.Configuration");

            await NavigationService.NavigateAsync("/AgendamentoNavigationPage/MenuPage");
        }


        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AgendamentoNavigationPage>();

            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AgendamentosPage, AgendamentosPageViewModel>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<AgendaPage, AgendaPageViewModel>();

            //Mock Service
            containerRegistry.RegisterSingleton<IAgendamentosService, AgendamentosService>();

        }

     
    }
}
