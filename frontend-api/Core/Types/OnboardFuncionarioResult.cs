using FrontEndAPI.Core.Models;

namespace FrontEndAPI.Core.Types;

public sealed class OnboardFuncionarioResult
{
    public Funcionario? Funcionario { get; set; }
    public bool MaquinaPronta { get; set; }
    public bool UsuarioRedeCriado { get; set; }
    public bool ParametroFolhaHabilitado { get; set; }
    public bool FuncionarioSalvo { get; set; }
}
