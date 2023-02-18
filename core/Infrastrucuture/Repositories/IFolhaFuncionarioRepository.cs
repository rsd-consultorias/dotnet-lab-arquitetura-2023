using System;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.Infrastrucuture.Repositories
{
    public interface IFolhaFuncionarioRepository : BaseRepository<FolhaFuncionario>
    {
        Task<IEnumerable<FolhaFuncionario>?> BuscarPorIdentificacao(string identificacao);
        Task<bool> ExcluirPorIdentificacao(string identificacao);
    }
}

