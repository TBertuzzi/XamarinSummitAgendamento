﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace XamarinSummitAgendamento
{
    public partial class CadastraConsultaPopup : PopupPage
    {
        public CadastraConsultaPopup()
        {
            InitializeComponent();
        }

        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }

        //protected override Task OnAppearingAnimationEndAsync()
        //{
        //    return Content.FadeTo(0.5);
        //}

        //protected override Task OnDisappearingAnimationBeginAsync()
        //{
        //    return Content.FadeTo(1);
        //}
    }
}
