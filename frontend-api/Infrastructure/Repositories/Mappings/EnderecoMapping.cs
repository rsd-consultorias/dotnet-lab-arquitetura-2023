using System;
using core.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabArquitetura.Infrastructure.Repositories.Mappings
{
	public class EnderecoMapping: IEntityTypeConfiguration<Endereco>
    {
		public EnderecoMapping()
		{
		}

        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(x => x.Id).HasConversion(e => e.ToString(), d => new Guid(d!)).HasColumnType("CHAR(36)");
            builder.Property(x => x.Bairro).HasColumnType("VARCHAR(240)");
            builder.Property(x => x.CEP).HasColumnType("CHAR(8)");
            builder.Property(x => x.Cidade).HasColumnType("CHAR(240)");
            builder.Property(x => x.CodigoCidadeIBGE).HasColumnType("CHAR(8)");
            builder.Property(x => x.Complemento).HasColumnType("VARCHAR(240)");
            builder.Property(x => x.Logradouro).HasColumnType("VARCHAR(240)");
            builder.Property(x => x.Numero).HasColumnType("VARCHAR(10)");
            builder.Property(x => x.TipoEndereco).HasColumnType("VARCHAR(20)");
            builder.Property(x => x.TipoLogradouro).HasColumnType("VARCHAR(20)");
            builder.Property(x => x.UF).HasColumnType("CHAR(2)");

            builder.Property(x => x.DataAlteracao).HasColumnType("DATETIME");
            builder.Property(x => x.DataCriacao).HasColumnType("DATETIME");
        }
    }
}

