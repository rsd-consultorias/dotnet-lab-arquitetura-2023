using System;
namespace LabArquitetura.Core.Models.ValueObjects
{
	public class RubricaFolha : BaseModel
    {
        public string? CodigoRubrica { get; set; }
        public string? DescricaoRubrica { get; set; }
        public decimal? Valor { get; set; }

        public RubricaFolha()
		{
		}
	}
}

