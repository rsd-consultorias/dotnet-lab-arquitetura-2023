﻿// <auto-generated />
using System;
using LabArquitetura.Infrastructure.DBContexts.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabArquitetura.Migrations
{
    [DbContext(typeof(LabArquiteturaDbContext))]
    [Migration("20230214152757_v1.0.1")]
    partial class v101
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("LabArquitetura.Core.Models.EventoFolha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CodigoEvento")
                        .HasColumnType("CHAR(4)");

                    b.Property<string>("CodigoTransacao")
                        .HasColumnType("CHAR(4)");

                    b.Property<DateTime?>("Data")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DataProcessamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("FuncionarioId")
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Historico")
                        .HasColumnType("CHAR(240)");

                    b.Property<bool>("Processado")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UltimoProcessamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Valor")
                        .HasColumnType("VARCHAR(32)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("EventoFolha");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.FolhaFuncionario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("DataProcessamento")
                        .HasColumnType("TEXT");

                    b.Property<string>("FuncionarioId")
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Identificacao")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("FolhaFuncionario");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.Funcionario", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("CHAR(11)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("VARCHAR(240)");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.ValueObjects.Documento", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime?>("Emissao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("FuncionarioId")
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Numero")
                        .HasColumnType("VARCHAR(40)");

                    b.Property<short?>("NumeroVia")
                        .HasColumnType("INT(2)");

                    b.Property<string>("OrgaoEmissor")
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("Tipo")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<DateTime?>("Validade")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Documento");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.ValueObjects.Endereco", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Bairro")
                        .HasColumnType("VARCHAR(240)");

                    b.Property<string>("CEP")
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("Cidade")
                        .HasColumnType("CHAR(240)");

                    b.Property<string>("CodigoCidadeIBGE")
                        .HasColumnType("CHAR(8)");

                    b.Property<string>("Complemento")
                        .HasColumnType("VARCHAR(240)");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("DATETIME");

                    b.Property<string>("FuncionarioId")
                        .HasColumnType("CHAR(36)");

                    b.Property<string>("Logradouro")
                        .HasColumnType("VARCHAR(240)");

                    b.Property<string>("Numero")
                        .HasColumnType("VARCHAR(10)");

                    b.Property<string>("TipoEndereco")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("TipoLogradouro")
                        .HasColumnType("VARCHAR(20)");

                    b.Property<string>("UF")
                        .HasColumnType("CHAR(2)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.ValueObjects.RubricaFolha", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CodigoRubrica")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataAlteracao")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT");

                    b.Property<string>("DescricaoRubrica")
                        .HasColumnType("TEXT");

                    b.Property<string>("FolhaFuncionarioId")
                        .HasColumnType("CHAR(36)");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FolhaFuncionarioId");

                    b.ToTable("RubricaFolha");
                });

            modelBuilder.Entity("LabArquitetura.Infrastructure.DBContexts.Models.QueueDbModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ActionType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Body")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Read")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Referrer")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.EventoFolha", b =>
                {
                    b.HasOne("LabArquitetura.Core.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.FolhaFuncionario", b =>
                {
                    b.HasOne("LabArquitetura.Core.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.OwnsOne("LabArquitetura.Core.Types.Periodo", "PeriodoFolha", b1 =>
                        {
                            b1.Property<string>("FolhaFuncionarioId")
                                .HasColumnType("CHAR(36)");

                            b1.Property<DateTime>("Fim")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("Inicio")
                                .HasColumnType("TEXT");

                            b1.HasKey("FolhaFuncionarioId");

                            b1.ToTable("FolhaFuncionario");

                            b1.WithOwner()
                                .HasForeignKey("FolhaFuncionarioId");
                        });

                    b.Navigation("Funcionario");

                    b.Navigation("PeriodoFolha");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.ValueObjects.Documento", b =>
                {
                    b.HasOne("LabArquitetura.Core.Models.Funcionario", null)
                        .WithMany("Documentos")
                        .HasForeignKey("FuncionarioId");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.ValueObjects.Endereco", b =>
                {
                    b.HasOne("LabArquitetura.Core.Models.Funcionario", null)
                        .WithMany("Enderecos")
                        .HasForeignKey("FuncionarioId");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.ValueObjects.RubricaFolha", b =>
                {
                    b.HasOne("LabArquitetura.Core.Models.FolhaFuncionario", null)
                        .WithMany("Rubricas")
                        .HasForeignKey("FolhaFuncionarioId");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.FolhaFuncionario", b =>
                {
                    b.Navigation("Rubricas");
                });

            modelBuilder.Entity("LabArquitetura.Core.Models.Funcionario", b =>
                {
                    b.Navigation("Documentos");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
