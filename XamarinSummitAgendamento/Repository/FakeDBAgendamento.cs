using System;
using System.Collections.Generic;
using XamarinSummitAgendamento.Models;

namespace XamarinSummitAgendamento.Repository
{
    //Armazena os dados pra simular um BD no APP
    public static class FakeDBAgendamento
    {
        public static List<Agendamento> Agendamentos { get; set; }

    }
}
