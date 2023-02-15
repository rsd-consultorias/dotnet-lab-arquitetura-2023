
using System;
using LabArquitetura.Core.Interfaces.Repositories;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Types;
using LabArquitetura.Infrastructure.DBContexts.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LabArquitetura.Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly LabArquiteturaDbContext _context;

        public FuncionarioRepository(LabArquiteturaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Funcionario>> ListarFuncionariosAtivosNoPeriodo(Periodo periodo)
        {
            return await Task.FromResult(_context.Funcionarios.AsNoTracking()
            .Include(x => x.Documentos)
            .Include(x => x.Enderecos)
                .OrderBy(x => x.Nome));
        }
    }
}

