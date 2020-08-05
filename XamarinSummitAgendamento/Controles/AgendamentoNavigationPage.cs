using System;
using Xamarin.Forms;
using XF.Material.Forms.UI;

namespace XamarinSummitAgendamento.Controles
{
    public class AgendamentoNavigationPage : MaterialNavigationPage
    {
        public AgendamentoNavigationPage(Page root) : base(root)
        {
            Title = root.Title;
            IconImageSource = root.IconImageSource;
            
        }


    }

}
