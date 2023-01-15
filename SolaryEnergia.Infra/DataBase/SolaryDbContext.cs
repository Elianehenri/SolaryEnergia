using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolaryEnergia.Domain.Models;
using SolaryEnergia.Infra.DataBase.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Infra.DataBase
{
    public class SolaryDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public SolaryDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Unidade> Unidades { get; set; }
        public DbSet<Geracao> Geracoes { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                _configuration.GetConnectionString("ConexaoBanco")
            );
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UnidadeMap());

            modelBuilder.ApplyConfiguration(new GeracaoMap());

            modelBuilder.ApplyConfiguration(new UserMap());
        }

    }
}
