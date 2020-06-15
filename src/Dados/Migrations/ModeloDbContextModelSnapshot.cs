﻿// <auto-generated />
using System;
using Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dados.Migrations
{
    [DbContext(typeof(ModeloDbContext))]
    partial class ModeloDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Negocio.Models.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnName("Bairro")
                        .HasColumnType("varchar(80)");

                    b.Property<string>("Cidade")
                        .HasColumnName("Cidade")
                        .HasColumnType("varchar(80)");

                    b.Property<Guid>("EntidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Numero")
                        .HasColumnName("Numero")
                        .HasColumnType("char(10)");

                    b.Property<string>("Rua")
                        .HasColumnName("Rua")
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("EntidadeId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Negocio.Models.Entidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(80)");

                    b.HasKey("Id");

                    b.ToTable("Entidades");
                });

            modelBuilder.Entity("Negocio.Models.Solicitacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .HasColumnName("Descricao")
                        .HasColumnType("varchar(80)");

                    b.Property<Guid>("EntidadeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EntidadeId");

                    b.ToTable("Solicitacoes");
                });

            modelBuilder.Entity("Negocio.Models.Endereco", b =>
                {
                    b.HasOne("Negocio.Models.Entidade", "Entidade")
                        .WithMany("Endereco")
                        .HasForeignKey("EntidadeId")
                        .IsRequired();
                });

            modelBuilder.Entity("Negocio.Models.Solicitacao", b =>
                {
                    b.HasOne("Negocio.Models.Entidade", "Entidade")
                        .WithMany("Solicitacao")
                        .HasForeignKey("EntidadeId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
