﻿// <auto-generated />
using System;
using LabArquitetura.Infrastructure.DbContexts.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LabArquitetura.Migrations
{
    [DbContext(typeof(LabArquiteturaDbContext))]
    [Migration("20230212030415_v2")]
    partial class v2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

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
                        .HasColumnType("TEXT")
                        .HasColumnName("DataAlteracao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("TEXT")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("LabArquitetura.Infrastructure.Repositories.Models.QueueDbModel", b =>
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

            modelBuilder.Entity("LabArquitetura.Core.Models.Funcionario", b =>
                {
                    b.OwnsMany("core.Models.ValueObjects.Documento", "Documentos", b1 =>
                        {
                            b1.Property<string>("FuncionarioId")
                                .HasColumnType("CHAR(36)");

                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("CHAR(36)");

                            b1.Property<DateTime?>("DataAlteracao")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("DataCriacao")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Emissao")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .HasColumnType("TEXT");

                            b1.Property<string>("OrgaoEmissor")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Tipo")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Validade")
                                .HasColumnType("TEXT");

                            b1.HasKey("FuncionarioId", "Id");

                            b1.ToTable("Documento");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioId");
                        });

                    b.OwnsMany("core.Models.ValueObjects.Endereco", "Enderecos", b1 =>
                        {
                            b1.Property<string>("FuncionarioId")
                                .HasColumnType("CHAR(36)");

                            b1.Property<string>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("CHAR(36)");

                            b1.Property<string>("CEP")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Cidade")
                                .HasColumnType("TEXT");

                            b1.Property<string>("CodigoCidadeIBGE")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Complemento")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("DataAlteracao")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime>("DataCriacao")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Logradouro")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Numero")
                                .HasColumnType("TEXT");

                            b1.Property<string>("TipoEndereco")
                                .HasColumnType("TEXT");

                            b1.Property<string>("TipoLogradouro")
                                .HasColumnType("TEXT");

                            b1.Property<string>("UF")
                                .HasColumnType("TEXT");

                            b1.HasKey("FuncionarioId", "Id");

                            b1.ToTable("Endereco");

                            b1.WithOwner()
                                .HasForeignKey("FuncionarioId");
                        });

                    b.Navigation("Documentos");

                    b.Navigation("Enderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
