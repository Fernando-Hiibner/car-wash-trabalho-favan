using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarWash.Models;

    public class CarWashContext : DbContext
    {
        public CarWashContext (DbContextOptions<CarWashContext> options)
            : base(options)
        {
        }

        public DbSet<CarWash.Models.ProprietarioModel> ProprietarioModel { get; set; }

        public DbSet<CarWash.Models.CarroModel> CarroModel { get; set; }

        public DbSet<CarWash.Models.ServicoModel> ServicoModel { get; set; }

        public DbSet<CarWash.Models.AgendamentoModel> AgendamentoModel { get; set; }
    }
