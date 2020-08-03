using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using XamarinSummitAgendamento.Controles;

namespace XamarinSummitAgendamento
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : Xamarin.Forms.TabbedPage
    {
        public MenuPage()
        {
            InitializeComponent();

            Xamarin.Forms.NavigationPage.SetHasNavigationBar(this, false);

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            Children.Add(new AgendamentoNavigationPage(new MainPage()));
            Children.Add(new AgendamentoNavigationPage(new AgendamentosPage()));
            Children.Add(new AgendamentoNavigationPage(new AgendaPage()));
        }
    }
}
