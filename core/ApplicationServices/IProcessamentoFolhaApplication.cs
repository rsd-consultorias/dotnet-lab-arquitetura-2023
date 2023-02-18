using System;
using LabArquitetura.Core.Types;

namespace Core.ApplicationServices
{
    public interface IProcessamentoFolhaApplication
    {
        Task<object> RodarFolhaNoPeriodo(Periodo periodo, string identificacao, Action<UInt16, string>? emitirStatusProcessamento = null);
        Task<object> RodarFolhaNoPeriodoParaFuncionarioId(Guid funcionarioId, Periodo periodo, string identificacao);
    }
}

