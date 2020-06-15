using Microsoft.EntityFrameworkCore;
using Negocio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados.Contexto
{
    public class ModeloDbContext : DbContext
    {
        public ModeloDbContext(DbContextOptions<ModeloDbContext> options) : base(options) { }

        public DbSet<Entidade> Entidades { get; set; }
        public DbSet<Solicitacao> Solicitacoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModeloDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
