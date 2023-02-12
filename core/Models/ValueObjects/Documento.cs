using System;
namespace core.Models.ValueObjects
{
	public class Documento
	{
		public Guid? Id { get; set; } = Guid.NewGuid();
		public string? Tipo { get; set; }
		public string? Numero { get; set; }
		public DateTime? Emissao { get; set; }
		public string? OrgaoEmissor { get; set; }
		public DateTime? Validade { get; set; }

		public Documento()
		{}
	}
}

