using System;
using LabArquitetura.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabArquitetura.Core.Infrastrucuture.DBContexts.Mappings
{
	public class FolhaFuncionarioMapping : IEntityTypeConfiguration<FolhaFuncionario>
    {
		public FolhaFuncionarioMapping()
		{
		}

        public void Configure(EntityTypeBuilder<FolhaFuncionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(e => e.ToString(), d => new Guid(d))
                .HasColumnType("CHAR(36)");

            builder.OwnsOne(x => x.PeriodoFolha, od =>
            {
                od.Property(x => x.Inicio).HasColumnName("PERIODO_INICIO").HasColumnType("DATETIME");
                od.Property(x => x.Fim).HasColumnName("PERIODO_FIM").HasColumnType("DATETIME");
            });

            builder.Property(x => x.DataAlteracao).HasColumnType("DATETIME");
            builder.Property(x => x.DataCriacao).HasColumnType("DATETIME");
        }
    }
}

