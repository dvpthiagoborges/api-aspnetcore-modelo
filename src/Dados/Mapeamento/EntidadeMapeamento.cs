using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Mapeamento
{
    public class EntidadeMapeamento : IEntityTypeConfiguration<Entidade>
    {
        public void Configure(EntityTypeBuilder<Entidade> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(80)");

            builder.ToTable("Entidades");
        }
    }
}
