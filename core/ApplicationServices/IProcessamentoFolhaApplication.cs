using System;
using LabArquitetura.Core.Types;

namespace Core.ApplicationServices
{
    public interface IProcessamentoFolhaApplication
    {
        Task RodarFolhaNoPeriodo(Periodo periodo, string identificacao, Action<UInt16, string>? emitirStatusProcessamento = null);
        Task RodarFolhaNoPeriodoParaFuncionarioId(Guid funcionarioId, Periodo periodo, string identificacao);
    }
}

