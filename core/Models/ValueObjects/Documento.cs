using System;
namespace LabArquitetura.Core.Models.ValueObjects
{
	public class Documento : BaseModel
	{
		public string? Tipo { get; set; }
		public string? Numero { get; set; }
		public DateTime? Emissao { get; set; }
		public string? OrgaoEmissor { get; set; }
		public DateTime? Validade { get; set; }
		public Int16? NumeroVia { get; set; }

		public Documento()
		{}
	}
}

