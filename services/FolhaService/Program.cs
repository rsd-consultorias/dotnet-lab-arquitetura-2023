using FolhaService.Services;
using FolhaWorker;
using LabArquitetura.Core.ApplicationServices;
using LabArquitetura.Core.Infrastrucuture.Commands;
using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Core.Infrastrucuture.Services;
using LabArquitetura.Core.Models;
using LabArquitetura.Infrastructure.DBContexts.Contexts;
using LabArquitetura.Infrastructure.Queries;
using LabArquitetura.Infrastructure.Services;
using LabArquitetura.Infrastructure.Commands;
using Microsoft.EntityFrameworkCore;
using core.ApplicationServices;
using core.Infrastrucuture.Queries;
using LabArquitetura.Core.Infrastrucuture.Repositories;
using LabArquitetura.Core.Interfaces.Repositories;
using LabArquitetura.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LabArquiteturaDbContext>(options =>
{
    options.UseSqlite("Data Source=/Users/rafaeldias/Repositories/dotnet/Lab-Arquitetura-2023/dotnet-lab-arquitetura-2023/frontend-api/labArquitetura.db;Cache=Shared", options => {
        options.MigrationsAssembly("frontend-api");
    });
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
}, ServiceLifetime.Singleton);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<ServiceStatus>();
builder.Services.AddSingleton<IFuncionarioQuery, FuncionarioQuery>();

builder.Services.AddSingleton<IEventoFolhaQuery, EventoFolhaQuery>();
builder.Services.AddSingleton<IFolhaFuncionarioRepository, FolhaFuncionarioRepository>();
builder.Services.AddSingleton<IFuncionarioRepository, FuncionarioRepository>();

builder.Services.AddSingleton<IProcessamentoFolhaApplication, ProcessamentoFolhaApplication>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5097, o => o.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<FolhaService.Services.FolhaService>();
app.MapGet("/", () => "gRPC service...");

app.Run();
