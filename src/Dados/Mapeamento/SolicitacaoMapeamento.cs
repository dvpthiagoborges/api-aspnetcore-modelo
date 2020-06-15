using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Mapeamento
{
    public class SolicitacaoMapeamento : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(80)");

            builder.HasOne(p => p.Entidade)
                .WithMany(b => b.Solicitacao)
                .HasForeignKey(p => p.EntidadeId);

            builder.ToTable("Solicitacoes");
        }
    }
}
