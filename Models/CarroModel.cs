using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWash.Models
{
    public class CarroModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }

        [Display(Name = "Proprietário")]
        public int ProprietarioId { get; set; }

        public virtual ProprietarioModel Proprietario { get; set; }

        public virtual ICollection<AgendamentoModel> Agendamentos { get; set; }

        public bool InserirAgendamento(AgendamentoModel agendamento)
        {
            try
            {
                foreach(AgendamentoModel agend in Agendamentos)
                {
                    if(agend.DataDeAgendamento == agendamento.DataDeAgendamento)
                    {
                        return false;
                    }
                }
                Agendamentos.Add(agendamento);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}