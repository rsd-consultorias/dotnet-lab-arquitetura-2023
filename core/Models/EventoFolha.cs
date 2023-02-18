using System;

namespace LabArquitetura.Core.Models
{
    public class EventoFolha : BaseModel
    {
        public DateTime? Data { get; set; }
        public string? CodigoTransacao { get; set; }
        public string? CodigoEvento { get; set; }
        public string? Descricao { get; set; }
        public string? Valor { get; set; }
        public string? Historico { get; set; }

        public Guid? FuncionarioId { get; set; }
        public virtual Funcionario? Funcionario { get; set; }

        public EventoFolha()
        {
        }

        public EventoFolha(string? codigoTransacao, string? codigoEvento, string? descricao, string? valor, string? historico, Guid? funcionarioId)
        {
            CodigoTransacao = codigoTransacao;
            CodigoEvento = codigoEvento;
            Descricao = descricao;
            Valor = valor;
            Historico = historico;
            FuncionarioId = funcionarioId;
        }
    }
}

