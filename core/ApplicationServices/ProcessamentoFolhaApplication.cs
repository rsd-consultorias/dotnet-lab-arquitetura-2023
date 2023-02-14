using System;
using core.Infrastrucuture.Queries;
using LabArquitetura.Core.Infrastrucuture.Repositories;
using LabArquitetura.Core.Interfaces.Repositories;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Models.ValueObjects;
using LabArquitetura.Core.Types;

namespace core.ApplicationServices
{
    public class ProcessamentoFolhaApplication : IProcessamentoFolhaApplication
    {
        private readonly IEventoFolhaQuery _eventoFolhaQuery;
        private readonly IFolhaFuncionarioRepository _folhaFuncionarioRepository;
        private readonly IFuncionarioRepository _funcionarioRepository;

        public ProcessamentoFolhaApplication(IEventoFolhaQuery eventoFolhaQuery,
            IFolhaFuncionarioRepository folhaFuncionarioRepository,
            IFuncionarioRepository funcionarioRepository)
        {
            _eventoFolhaQuery = eventoFolhaQuery;
            _folhaFuncionarioRepository = folhaFuncionarioRepository;
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<object> RodarFolhaNoPeriodo(Periodo periodo, string identificacao, Action<UInt16, string>? emitirStatusProcessamento = null)
        {
            //var folhaProcessada = await _folhaFuncionarioRepository.BuscarPorPeriodoEIdentificacao(periodo, identificacao)!;

            //if (folhaProcessada != null && folhaProcessada.Any())
            //{
            //    await _folhaFuncionarioRepository.ExcluirFolhaProcessadaNoPeriodoEIdentificacao(periodo, identificacao);
            //}

            //var funcionariosAtivos = await _funcionarioRepository.ListarFuncionariosAtivosNoPeriodo(periodo);
            //var unidadeProgresso = ((ushort)(99 / funcionariosAtivos!.Count()));
            //UInt16 progresso = unidadeProgresso;

            //foreach (var funcionario in funcionariosAtivos)
            //{
            //    var folhaFuncionario = new FolhaFuncionario
            //    {
            //        Identificacao = identificacao,
            //        PeriodoFolha = periodo,
            //        DataProcessamento = DateTime.UtcNow
            //    };

            //    foreach (var evento in await _eventoFolhaQuery.ListarEventosNaoProcessadosPorFuncionarioId(funcionario.Id, periodo))
            //    {
            //        evento.UltimoProcessamento = evento.DataProcessamento;
            //        evento.DataProcessamento = DateTime.UtcNow;
            //        evento.Processado = true;

            //        ((List<RubricaFolha>)(folhaFuncionario.Rubricas!)).Add(new RubricaFolha
            //        {
            //            CodigoRubrica = evento.CodigoEvento,
            //            DescricaoRubrica = evento.Descricao,
            //            Valor = decimal.Parse(evento.Valor!) / 100
            //        });
            //        emitirStatusProcessamento!(progresso, $"Processando: [{progresso}%] {funcionario.CPF} => Evento: {evento.CodigoTransacao}.{evento.CodigoEvento} - {evento.Descricao}...");
            //    }

            //    await _folhaFuncionarioRepository.Gravar(folhaFuncionario);

            //    progresso += unidadeProgresso;
            //    emitirStatusProcessamento!(progresso, $"Processando: [{progresso}%] {funcionario.CPF}...");
            //}

            for (ushort i = 0; i < 100; i+=5){
                emitirStatusProcessamento!(i, "Executando...");
                await Task.Delay(6000);
            }

            emitirStatusProcessamento!(100, "Processamento da folha finalizado.");

            return Task.CompletedTask;
        }

        public Task<object> RodarFolhaNoPeriodoParaFuncionarioId(Guid funcionarioId, Periodo periodo, string identificacao)
        {
            throw new NotImplementedException();
        }
    }
}

