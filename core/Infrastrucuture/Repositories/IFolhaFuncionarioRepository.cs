using System;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.Infrastrucuture.Repositories
{
    public interface IFolhaFuncionarioRepository : BaseRepository<FolhaFuncionario>
    {
        Task<IEnumerable<FolhaFuncionario>?> BuscarPorPeriodoEIdentificacao(Periodo periodo, string identificacao);
        Task<bool> ExcluirFolhaProcessadaNoPeriodoEIdentificacao(Periodo periodo, string identificacao);
    }
}

