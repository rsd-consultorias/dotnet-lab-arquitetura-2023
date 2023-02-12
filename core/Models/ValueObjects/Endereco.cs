using System;
namespace core.Models.ValueObjects
{
    public class Endereco : BaseModel
    {
        public string? TipoEndereco { get; set; }
        public string? TipoLogradouro { get; set; }
        public string? Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? CodigoCidadeIBGE { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }

        public Endereco()
        {
        }
    }
}
