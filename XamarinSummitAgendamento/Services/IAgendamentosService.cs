using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSummitAgendamento.Models;

namespace XamarinSummitAgendamento.Services
{
    public interface IAgendamentosService
    {
        List<Agendamento> ObterAgendamentos();
        void InserirAgendamento(Agendamento agendamento);
    }
}
