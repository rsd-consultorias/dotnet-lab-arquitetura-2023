using Microsoft.EntityFrameworkCore;
using LabArquitetura.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Repositories.Mappings
{
    public class FuncionarioDBMapping : IEntityTypeConfiguration<Funcionario>
    {
        public FuncionarioDBMapping()
        {
        }

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasConversion(e => e.ToString(), d => new Guid(d))
                .HasColumnType("VARCHAR(36)");

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("CHAR(11)");

            builder.OwnsMany(x => x.Documentos).Property(x=>x.Id).HasConversion(e => e.ToString(), d => new Guid(d!)).HasMaxLength(36);
            builder.OwnsMany(x => x.Enderecos).Property(x => x.Id).HasConversion(e => e.ToString(), d => new Guid(d!)).HasMaxLength(36);

            builder.Property(x => x.EMail).IsRequired();

            builder.HasIndex(x => x.CPF).IsUnique();

            builder.Property(x => x.DataCriacao).HasColumnName("DataCriacao");
            builder.Property(x => x.DataAlteracao).HasColumnName("DataAlteracao");
        }
    }
}

