using System;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;
using LabArquitetura.Infrastructure.DBContexts.Contexts;
using Microsoft.EntityFrameworkCore;

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
            var result = _context.FolhaFuncionario.AsNoTracking().Where(x => x.Identificacao!.Equals(identificacao)).AsEnumerable<FolhaFuncionario>();
            return result;
        }

        public async Task<bool> ExcluirFolhaProcessadaNoPeriodoEIdentificacao(Periodo periodo, string identificacao)
        {
            var result = _context.FolhaFuncionario.Include(x => x.Rubricas).Where(x => x.Identificacao!.Equals(identificacao));
            _context.FolhaFuncionario.RemoveRange(result);
            var removed = await _context.SaveChangesAsync();
            return removed > 0;
        }

        public async Task<bool> Gravar(FolhaFuncionario model)
        {
            await _context.FolhaFuncionario.AddAsync(model);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

