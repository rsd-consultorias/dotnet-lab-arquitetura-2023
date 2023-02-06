using LabArquitetura.Core.Models;

namespace LabArquitetura.Core.Types
{

    public sealed class OnboardFuncionarioResult<TModel> where TModel : Funcionario
    {
        public TModel? Funcionario { get; set; }
        public bool MaquinaPronta { get; set; }
        public bool UsuarioRedeCriado { get; set; }
        public bool ParametroFolhaHabilitado { get; set; }
        public bool FuncionarioSalvo { get; set; }
    }
}