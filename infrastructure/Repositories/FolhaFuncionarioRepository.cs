using System;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.Infrastrucuture.Repositories
{
    public class FolhaFuncionarioRepository : IFolhaFuncionarioRepository
    {
        public FolhaFuncionarioRepository()
        {
        }

        public async Task<bool> Atualizar(FolhaFuncionario model)
        {
            return true;
        }

        public async Task<IEnumerable<FolhaFuncionario>?> BuscarPorPeriodoEIdentificacao(Periodo periodo, string identificacao)
        {
            return new List<FolhaFuncionario> { new FolhaFuncionario {
                
            } };
        }

        public async Task<bool> ExcluirFolhaProcessadaNoPeriodoEIdentificacao(Periodo periodo, string identificacao)
        {
            return true;
        }

        public async Task<bool> Gravar(FolhaFuncionario model)
        {
            return true;
        }
    }
}

