﻿using System;
namespace LabArquitetura.Infrastructure.DBContexts.Models
{
    public abstract class AuditoriaDbModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataAlteracao { get; set; }

        public AuditoriaDbModel()
        {
        }
    }
}

