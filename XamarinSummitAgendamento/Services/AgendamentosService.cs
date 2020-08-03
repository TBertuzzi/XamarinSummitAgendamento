using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinSummitAgendamento.Models;
using XamarinSummitAgendamento.Repository;

namespace XamarinSummitAgendamento.Services
{
    //Serviço Mockado para simular diversos agendamentos
    public class AgendamentosService : IAgendamentosService
    {
        public AgendamentosService()
        {
            var agendamento1 = new Agendamento
            {
                Exame = "Exame geral",
                CEP = "09087-992",
                DataHora = DateTime.Now,
                CPF = "909908765-00",
                Observacao = "Lembrar de levar os papeis"
            };

            FakeDBAgendamento.Agendamentos.Add(agendamento1);

            var agendamento2 = new Agendamento
            {
                Exame = "Exame no Figado",
                CEP = "09087-993",
                DataHora = DateTime.Now.AddDays(5),
                CPF = "909908765-00",
                Observacao = "Lembrar de não beber 24 horas antes"
            };

            FakeDBAgendamento.Agendamentos.Add(agendamento2);

            var agendamento3 = new Agendamento
            {
                Exame = "Exame no Rim",
                CEP = "09087-992",
                DataHora = DateTime.Now.AddDays(-3),
                CPF = "909908765-00",
                Observacao = "Lembrar de beber Agua"
            };

            FakeDBAgendamento.Agendamentos.Add(agendamento3);
        }


        public void InserirAgendamento(Agendamento agendamento)
        {
            FakeDBAgendamento.Agendamentos.Add(agendamento);
        }

        public List<Agendamento> ObterAgendamentos()
        {
            return FakeDBAgendamento.Agendamentos;
        }
    }
}
