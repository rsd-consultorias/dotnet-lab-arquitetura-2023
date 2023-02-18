
using System;
using LabArquitetura.Core.Models;

namespace LabArquitetura.ViewModels
{
    public class EventoFolhaRequest : ApiRequest
    {
        public DateTime? Data { get; private set; } = DateTime.UtcNow;
        public string? CodigoTransacao { get; private set; }
        public string? CodigoEvento { get; private set; }
        public string? Descricao { get; private set; }
        public string? Valor { get; private set; }
        public string? Historico { get; private set; }

        public Guid? FuncionarioId { get; private set; }

        public EventoFolhaRequest(string? codigoTransacao,
            string? codigoEvento,
            string? descricao,
            string? valor,
            string? historico,
            Guid? funcionarioId)
        {
            CodigoTransacao = codigoTransacao;
            CodigoEvento = codigoEvento;
            Descricao = descricao;
            Valor = valor;
            Historico = historico;
            FuncionarioId = funcionarioId;
        }

        public EventoFolha ToModel()
        {
            return new EventoFolha()
            {
                Data = Data,
                CodigoTransacao = CodigoTransacao,
                CodigoEvento = CodigoEvento,
                Descricao = Descricao,
                Valor = Valor,
                Historico = Historico,
                FuncionarioId = FuncionarioId
            };
        }
    }
}

