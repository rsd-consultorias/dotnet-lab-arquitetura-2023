﻿using Microsoft.EntityFrameworkCore;
using LabArquitetura.Infrastructure.Repositories.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabArquitetura.Infrastructure.Repositories.Mappings
{
	public class FuncionarioDBMapping : IEntityTypeConfiguration<FuncionarioDbModel>
	{
		public FuncionarioDBMapping()
		{
		}

        public void Configure(EntityTypeBuilder<FuncionarioDbModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11);

            builder.Property(x => x.EMail).IsRequired();

            builder.HasIndex(x => x.CPF).IsUnique(true);
        }
    }
}
