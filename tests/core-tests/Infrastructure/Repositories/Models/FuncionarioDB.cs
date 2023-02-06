﻿using LabArquitetura.Core.Models;

namespace LabArquitetura.Infrastructure.Repositories.Models
{
	public class FuncionarioDB : Funcionario
    {
		public int Id { get; set; }

        public override string? CPF { get; protected set; }
        public override string? Nome { get; protected set; }
        public override string? EMail { get; protected set; }

        public FuncionarioDB()
        {

        }

        public FuncionarioDB(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            EMail = email;
        }
    }
}
