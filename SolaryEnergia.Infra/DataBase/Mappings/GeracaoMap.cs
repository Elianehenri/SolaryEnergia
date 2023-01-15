using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Infra.DataBase.Mappings
{
    public class GeracaoMap : IEntityTypeConfiguration<Geracao>
    {
        public void Configure(EntityTypeBuilder<Geracao> builder)
        {
            builder.ToTable("Geraçoes");

            builder.HasKey(g => g.Id);

            builder
                .Property(g => g.Data)
                .IsRequired();

            builder
                .Property(g => g.Kw)
                .HasColumnType("int")
                .IsRequired() ;

            //chave estrangeira
            builder
                .HasOne(g => g.Unidade)
                .WithMany(u => u.Geracoes)
                .HasForeignKey(g => g.UnidadeId);
        }
    }
}
