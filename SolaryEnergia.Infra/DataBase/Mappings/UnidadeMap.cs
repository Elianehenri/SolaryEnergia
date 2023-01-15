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
    public class UnidadeMap : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder.ToTable("Unidades");

            builder.HasKey(u => u.Id);

            builder
                .Property(u => u.Apelido)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property(u => u.Local)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(u => u.Marca)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();
            builder
                .Property(u => u.Modelo)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(u => u.IsActive)
                .IsRequired();


        }
    }
}
