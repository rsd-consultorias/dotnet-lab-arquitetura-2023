global using NUnit.Framework;
global using FrontEndAPI.Infrastructure.Queries;
global using FrontEndAPI.Infrastructure.Services;
global using FrontEndAPI.Core.DomainServices;
global using FrontEndAPI.Core.Interfaces;
global using FrontEndAPI.Core.ApplicationServices;
global using FrontEndAPI.Core.Models;

public class FuncionariosSource
    {
        public static IEnumerable<Funcionario> Validos()
        {
            var lista = new List<Funcionario>();
            lista.Add(new Funcionario("34745678901", "DB Funcionario de Testes 1", "fute1@teste.com"));
            lista.Add(new Funcionario("34745678902", "Funcionario de Testes 2", "fute2@teste.com"));
            lista.Add(new Funcionario("34745678903", "Funcionario de Testes 3", "fute3@teste.com"));
            lista.Add(new Funcionario("34745678904", "Funcionario de Testes 4", "fute4@teste.com"));
            return lista;
        }
        
        public static IEnumerable<Funcionario> Invalidos()
        {
            var lista = new List<Funcionario>();
            lista.Add(new Funcionario("3474567891", "DB Funcionario de Testes 1", "fute1@teste.com"));
            lista.Add(new Funcionario("347458902", "Funcionario de Testes 2", "fute2@teste.com"));
            lista.Add(new Funcionario("34778903", "Funcionario de Testes 3", "fute3@teste.com"));
            lista.Add(new Funcionario("3474565435378904", "Funcionario de Testes 4", "fute4@teste.com"));
            return lista;
        }
    }