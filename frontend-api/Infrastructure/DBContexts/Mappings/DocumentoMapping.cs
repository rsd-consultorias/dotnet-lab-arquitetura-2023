using System;
using core.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabArquitetura.Infrastructure.DbContexts.Mappings
{
	public class DocumentoMapping: IEntityTypeConfiguration<Documento>
    {
		public DocumentoMapping()
		{
		}

        public void Configure(EntityTypeBuilder<Documento> builder)
        {
            builder.Property(x => x.Id).HasConversion(e => e.ToString(), d => new Guid(d!)).HasColumnType("CHAR(36)");
            builder.Property(x => x.Emissao).HasColumnType("DATETIME");
            builder.Property(x => x.Numero).HasColumnType("VARCHAR(40)");
            builder.Property(x => x.NumeroVia).HasColumnType("INT(2)");
            builder.Property(x => x.OrgaoEmissor).HasColumnType("VARCHAR(120)");
            builder.Property(x => x.Tipo).HasColumnType("VARCHAR(20)");
            builder.Property(x => x.Validade).HasColumnType("DATETIME");

            builder.Property(x => x.DataAlteracao).HasColumnType("DATETIME");
            builder.Property(x => x.DataCriacao).HasColumnType("DATETIME");
        }
    }
}

