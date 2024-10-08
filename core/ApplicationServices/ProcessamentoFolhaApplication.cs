﻿using System;
using System.Linq;
using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Core.Infrastrucuture.Repositories;
using LabArquitetura.Core.Interfaces.Repositories;
using LabArquitetura.Core.Models;
using LabArquitetura.Core.Models.ValueObjects;
using LabArquitetura.Core.Types;

namespace LabArquitetura.Core.ApplicationServices
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

        public async Task RodarFolhaNoPeriodo(Periodo periodo, string identificacao, Action<UInt16, string>? emitirStatusProcessamento = null)
        {
            var folhaProcessada = await _folhaFuncionarioRepository.BuscarPorIdentificacao(identificacao)!;

            if (folhaProcessada != null && folhaProcessada.Any())
            {
                await _folhaFuncionarioRepository.ExcluirPorIdentificacao(identificacao);
            }

            var funcionariosAtivos = await _funcionarioRepository.ListarFuncionariosAtivosNoPeriodo(periodo);
            var quantidadeEtapasProcessamento = funcionariosAtivos!.Count() + 1;
            UInt16 progresso = (ushort)(100 / quantidadeEtapasProcessamento);
            UInt16 unidadeProgresso = (ushort)(100 / quantidadeEtapasProcessamento);

            for (ushort i = 0; i < progresso; i++)
            {
                emitirStatusProcessamento!(i, "Configurando processamento");
            }

            foreach (var funcionario in funcionariosAtivos)
            {
                var folhaFuncionario = new FolhaFuncionario(identificacao, DateTime.UtcNow, new Periodo { Inicio = periodo.Inicio, Fim = periodo.Fim }, funcionario.Id);

                var eventosGrupo = from eventoFolha in await _eventoFolhaQuery.ListarEventosPorFuncionarioIdEPeriodo(funcionario.Id, periodo)
                                   group new { CodigoTransacao = eventoFolha.CodigoTransacao, CodigoEvento = eventoFolha.CodigoEvento, Valor = eventoFolha.Valor! }
                                   by new { eventoFolha.CodigoTransacao, eventoFolha.CodigoEvento }
                        into eventoFolhaGroup
                                   select eventoFolhaGroup;

                foreach (var grupo in eventosGrupo)
                {
                    var rubrica = new RubricaFolha(grupo.Key.CodigoEvento, $"Rubrica Transacao/Evento {grupo.Key.CodigoTransacao}/{grupo.Key.CodigoEvento}", grupo.Sum(x => decimal.Parse(x.Valor) / 100));

                    ((List<RubricaFolha>)(folhaFuncionario.Rubricas!)).Add(rubrica);
                }

                await _folhaFuncionarioRepository.Gravar(folhaFuncionario);

                emitirStatusProcessamento!(progresso, $"Processando: [{funcionario.CPF}] {funcionario.Nome}");
                progresso += unidadeProgresso;
            }

            for (var i = progresso; i < 100; i++)
            {
                emitirStatusProcessamento!(i, "Finalizando processamento");
            }

            emitirStatusProcessamento!(100, "Processamento da folha finalizado.");
        }

        public Task RodarFolhaNoPeriodoParaFuncionarioId(Guid funcionarioId, Periodo periodo, string identificacao)
        {
            throw new NotImplementedException();
        }
    }
}

