global using NUnit.Framework;
global using LabArquitetura.Infrastructure.Queries;
global using LabArquitetura.Infrastructure.Services;
global using LabArquitetura.Core.DomainServices;
global using LabArquitetura.Core.Infrastrucuture;
global using LabArquitetura.Core.ApplicationServices;
global using LabArquitetura.Infrastructure.DBContexts.Models;

public class FuncionariosSource
{
    public static IEnumerable<FuncionarioDB> Validos()
    {
        var lista = new List<FuncionarioDB>
        {
            new FuncionarioDB("34745678901", "DB Funcionario de Testes 1", "fute1@teste.com"),
            new FuncionarioDB("34745678902", "Funcionario de Testes 2", "fute2@teste.com"),
            new FuncionarioDB("34799978903", "Funcionario de Testes 3", "fute3@teste.com"),
            new FuncionarioDB("34745678904", "Funcionario de Testes 4", "fute4@teste.com")
        };
        return lista;
    }

    public static IEnumerable<FuncionarioDB> Invalidos()
    {
        var lista = new List<FuncionarioDB>
        {
            new FuncionarioDB("3474567891", "DB Funcionario de Testes 1", "fute1@teste.com"),
            new FuncionarioDB("347458902", "Funcionario de Testes 2", "fute2@teste.com"),
            new FuncionarioDB("34778903", "Funcionario de Testes 3", "fute3@teste.com"),
            new FuncionarioDB("3474565435378904", "Funcionario de Testes 4", "fute4@teste.com")
        };
        return lista;
    }
}