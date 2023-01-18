using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolaryEnergia.Domain.Enuns;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Infra.DataBase.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(n => n.Id);

            builder
                .Property(n => n.Nome)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(n => n.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(80)
                .IsRequired();

            builder
                .Property (n => n.Password)
                .HasColumnType ("VARCHAR")
                .HasMaxLength (64)
                .IsRequired();

            builder
                 .Property(u => u.Role)
                        .HasMaxLength(50)
                        .IsRequired();



        }
    }
}
