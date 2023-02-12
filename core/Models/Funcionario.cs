using core.Models;
using core.Models.ValueObjects;

namespace LabArquitetura.Core.Models
{

    public class Funcionario : BaseModel
    {
        public string? CPF { get; set; }
        public string? Nome { get; set; }
        public string? EMail { get; set; }

        public IEnumerable<Documento>? Documentos { get; set; }
        public IEnumerable<Endereco>? Enderecos { get; set; }

        public Funcionario()
        { }

        public Funcionario(string cpf, string nome, string email)
        {
            CPF = cpf;
            Nome = nome;
            EMail = email;
        }

        public void AddEndereco(string? tipoEndereco,
            string? cep,
            string? numero = null,
            string? tipoLogradouro = null,
            string? logradouro = null,
            string? complemento = null,
            string? bairro = null,
            string? cidade = null,
            string? uf = null)
        {
            ((List<Endereco>)Enderecos!).Add(new Endereco
            {
                TipoEndereco = tipoEndereco,
                CEP = cep,
                Numero = numero,
                Complemento = complemento,
                Bairro = bairro,
                UF = uf,
                Cidade = cidade,
                Logradouro = logradouro,
                TipoLogradouro = tipoLogradouro
            });
        }

        public void AddDocumento(string? tipo,
            string? numero,
            DateTime? emissao = null,
            string? orgaoEmisso = null,
            DateTime? validade = null,
            Int16? numeroVia = null)
        {
            ((List<Documento>)Documentos!).Add(new Documento()
            {
                Tipo = tipo,
                Emissao = emissao,
                Validade = validade,
                Numero = numero,
                OrgaoEmissor = orgaoEmisso,
                NumeroVia = numeroVia
            });
        }
    }
}