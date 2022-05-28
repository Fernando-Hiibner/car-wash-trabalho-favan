using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWash.Models
{
    public class AgendamentoModel
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Agendamento")]
        public DateTime DataDeAgendamento { get; set; }

        [Display(Name = "Carro")]
        public int CarroId { get; set; }
        [Display(Name = "Serviço")]
        public int ServicoId { get; set; }

        public virtual CarroModel Carro { get; set; }
        public virtual ServicoModel Servico { get; set; }
    }
}