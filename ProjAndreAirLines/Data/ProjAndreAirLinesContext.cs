using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjAndreAirLines.Model;

namespace ProjAndreAirLines.Data
{
    public class ProjAndreAirLinesContext : DbContext
    {
        public ProjAndreAirLinesContext (DbContextOptions<ProjAndreAirLinesContext> options)
            : base(options)
        {
        }

        public DbSet<ProjAndreAirLines.Model.Voo> Voo { get; set; }

        public DbSet<ProjAndreAirLines.Model.PrecoBase> PrecoBase { get; set; }

        public DbSet<ProjAndreAirLines.Model.Passagem> Passagem { get; set; }

        public DbSet<ProjAndreAirLines.Model.Passageiro> Passageiro { get; set; }

        public DbSet<ProjAndreAirLines.Model.Endereco> Endereco { get; set; }

        public DbSet<ProjAndreAirLines.Model.Classe> Classe { get; set; }

        public DbSet<ProjAndreAirLines.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<ProjAndreAirLines.Model.Aeronave> Aeronave { get; set; }
    }
}
