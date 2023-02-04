using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Core.Models;
using FrontEndAPI.Infrastructure.Repositories.Contexts;

namespace FrontEndAPI.Infrastructure.Commands;

public class FuncionarioCommand : IFuncionarioCommand
{
    private readonly LabArquiteturaDbContext _context;

    public FuncionarioCommand(LabArquiteturaDbContext context)
    {
        _context = context;
    }

    public bool Salvar(Funcionario funcionario)
    {
        this._context.Funcionarios.Add(funcionario);
        this._context.SaveChanges();

        return true;
    }
}