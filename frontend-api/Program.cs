using System.Reflection;
using LabArquitetura.Core.ApplicationServices;
using LabArquitetura.Core.Infrastrucuture;
using LabArquitetura.Core.Infrastrucuture.Queries;
using LabArquitetura.Core.Infrastrucuture.Commands;
using LabArquitetura.Core.Infrastrucuture.Services;
using LabArquitetura.Infrastructure.DBContexts.Models;
using LabArquitetura.Infrastructure.Queries;
using LabArquitetura.Infrastructure.DBContexts.Contexts;
using LabArquitetura.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Keycloak.AuthServices.Authentication;
using LabArquitetura.Infrastructure.Commands;
using Serilog;
using LabArquitetura.Core.Models;
using FolhaServiceGRPC;
using static FolhaServiceGRPC.FolhaServiceStatus;

var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.WriteTo.Console();
});

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddDbContext<LabArquiteturaDbContext>(options =>
{
    //options.UseInMemoryDatabase("LabArquitetura", op => { op.EnableNullChecks(); });
    options.UseSqlite("Data Source=labArquitetura.db;Cache=Shared", options =>
    {
        options.MigrationsAssembly("frontend-api");
    });
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
    //options.MigrationsAssembly("frontend-api");
}, ServiceLifetime.Scoped);

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:4200/", "*");
        policy.AllowAnyHeader();
        policy.AllowCredentials();
        policy.AllowAnyMethod();
        policy.Build();
    });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Lab Arquitetura 2023",
        Version = "v1"
    });
    config.ResolveConflictingActions(x => x.First());

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    config.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
});

// gRPC clients
builder.Services.AddGrpcClient<FolhaServiceStatusClient>(options =>
{
    options.Address = new Uri("http://localhost:5097");
});

// Authentication & Authorization
builder.Services.AddKeycloakAuthentication(builder.Configuration);

// Inject dependencies
/// ver: [Diretrizes de injeção de dependência](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection-guidelines)
builder.Services.AddScoped<IEMailService, EMailService>();
builder.Services.AddScoped<IFolhaService, FolhaService>();
builder.Services.AddScoped<IMaquinaQuery, MaquinaQuery>();
builder.Services.AddScoped<IUsuarioQuery, UsuarioQuery>();
builder.Services.AddScoped<IFuncionarioCommand<Funcionario>, FuncionarioCommand>();
builder.Services.AddScoped<IEventoFolhaCommand, EventoFolhaCommand>();
builder.Services.AddScoped<IFuncionarioQuery, FuncionarioQuery>();
builder.Services.AddScoped<IOnboardingApplication<Funcionario>, OnboardingApplication<Funcionario>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors("allowall");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
//     // .RequireAuthorization("ApiScope");
// });

app.MapControllers();

app.Run();
