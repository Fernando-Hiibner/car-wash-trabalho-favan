using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarWash.Models
{
    public class ServicoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
    }
}