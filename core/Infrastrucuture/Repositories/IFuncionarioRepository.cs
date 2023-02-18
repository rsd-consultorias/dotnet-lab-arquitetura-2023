using System;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.Interfaces.Repositories
{
    public interface IFuncionarioRepository
    {
        Task<IEnumerable<Funcionario>> ListarFuncionariosAtivosNoPeriodo(Periodo periodo);
    }
}

