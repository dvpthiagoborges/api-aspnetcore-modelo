using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Mapeamento
{
    public class EnderecoMapeamento : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Rua)
                .HasColumnName("Rua")
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Numero)
                .HasColumnName("Numero")
                .HasColumnType("char(10)");

            builder.Property(p => p.Bairro)
                .HasColumnName("Bairro")
                .HasColumnType("varchar(80)");

            builder.Property(p => p.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(80)");

            builder.HasOne(p => p.Entidade)
                .WithMany(b => b.Endereco)
                .HasForeignKey(p => p.EntidadeId);

            builder.ToTable("Enderecos");
        }
    }
}
