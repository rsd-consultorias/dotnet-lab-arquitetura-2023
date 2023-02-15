using System;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;
using LabArquitetura.Infrastructure.DBContexts.Contexts;

namespace LabArquitetura.Core.Infrastrucuture.Repositories
{
    public class FolhaFuncionarioRepository : IFolhaFuncionarioRepository
    {
        private readonly LabArquiteturaDbContext _context;

        public FolhaFuncionarioRepository(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Atualizar(FolhaFuncionario model)
        {
            return true;
        }

        public async Task<IEnumerable<FolhaFuncionario>?> BuscarPorPeriodoEIdentificacao(Periodo periodo, string identificacao)
        {
            return await Task.FromResult(new List<FolhaFuncionario> { new FolhaFuncionario {
                
            } });
        }

        public async Task<bool> ExcluirFolhaProcessadaNoPeriodoEIdentificacao(Periodo periodo, string identificacao)
        {
            return true;
        }

        public async Task<bool> Gravar(FolhaFuncionario model)
        {
            await _context.FolhaFuncionario.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

