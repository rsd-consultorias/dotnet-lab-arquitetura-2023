using System;
using LabArquitetura.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabArquitetura.Infrastructure.DBContexts.Mappings
{
    public class EventoFolhaMapping : IEntityTypeConfiguration<EventoFolha>
    {
        public EventoFolhaMapping()
        {
        }

        public void Configure(EntityTypeBuilder<EventoFolha> builder)
        {
            builder.HasOne<Funcionario>(x => x.Funcionario);
            builder.Property(x => x.CodigoTransacao).HasColumnType("CHAR(4)");
            builder.Property(x => x.CodigoEvento).HasColumnType("CHAR(4)");
            builder.Property(x => x.Valor).HasColumnType("VARCHAR(32)");
            builder.Property(x => x.Historico).HasColumnType("CHAR(240)");

            builder.Property(x => x.DataAlteracao).HasColumnType("DATETIME");
            builder.Property(x => x.DataCriacao).HasColumnType("DATETIME");
        }
    }
}

