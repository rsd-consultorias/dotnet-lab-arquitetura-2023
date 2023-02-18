using System;
using LabArquitetura.Core.Models.ValueObjects;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.Models
{
    public class FolhaFuncionario : BaseModel
    {
        public string? Identificacao { get; set; }
        public DateTime? DataProcessamento { get; set; }
        public Periodo? PeriodoFolha { get; set; }

        public Guid? FuncionarioId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        public IEnumerable<RubricaFolha>? Rubricas { get; set; } = new List<RubricaFolha>();


        public FolhaFuncionario()
        {
        }

        public FolhaFuncionario(string? identificacao, DateTime? dataProcessamento, Periodo? periodoFolha, Guid? funcionarioId)
        {
            Identificacao = identificacao;
            DataProcessamento = dataProcessamento;
            PeriodoFolha = periodoFolha;
            FuncionarioId = funcionarioId;
        }
    }
}

