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
	}
}

