using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWash.Models
{
    public class ProprietarioModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }

        public int Idade
        {
            get
            {
                return DateTime.Now.Year - DataDeNascimento.Year;
            }
        }
        public virtual ICollection<CarroModel> Carros { get; set; }

        public bool ChecarValidade()
        {
            if (Idade < 18)
            {
                return false;
            }
            return true;
        }
    }
}