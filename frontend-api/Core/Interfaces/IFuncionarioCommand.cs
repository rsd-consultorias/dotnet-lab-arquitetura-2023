using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.Interfaces;

public interface IFuncionarioCommand {
    bool Salvar(Funcionario funcionario);
}