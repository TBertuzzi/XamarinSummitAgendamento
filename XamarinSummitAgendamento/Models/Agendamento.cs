using System;
namespace XamarinSummitAgendamento.Models
{
    public class Agendamento
    {
        public string Exame { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public DateTime DataHora { get; set; }
        public string Observacao { get; set; }
    }
}
