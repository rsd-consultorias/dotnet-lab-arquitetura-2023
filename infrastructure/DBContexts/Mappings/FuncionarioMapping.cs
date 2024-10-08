﻿using Microsoft.EntityFrameworkCore;
using LabArquitetura.Infrastructure.DBContexts.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.DBContexts.Mappings
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(e => e.ToString(), d => new Guid(d))
                .HasColumnType("CHAR(36)");

            builder.Property(x => x.Nome).HasColumnType("VARCHAR(240)");

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("CHAR(11)");

            builder.HasMany(x => x.Documentos);

            builder.HasMany(x => x.Enderecos);

            builder.Property(x => x.EMail).IsRequired();

            builder.HasIndex(x => x.CPF).IsUnique();

            builder.Property(x => x.DataAlteracao).HasColumnType("DATETIME");
            builder.Property(x => x.DataCriacao).HasColumnType("DATETIME");
        }
    }
}

