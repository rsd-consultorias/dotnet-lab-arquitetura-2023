
using System;
using LabArquitetura.Core.Interfaces.Repositories;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Infrastructure.Repositories
{
	public class FuncionarioRepository : IFuncionarioRepository
    {
		public FuncionarioRepository()
		{
		}

        public Task<IEnumerable<Funcionario>> ListarFuncionariosAtivosNoPeriodo(Periodo periodo)
        {
            return null;
        }
    }
}

