using System.Reflection;
using FrontEndAPI.Core.ApplicationServices;
using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Infrastructure.Queries;
using FrontEndAPI.Infrastructure.Repositories.Contexts;
using FrontEndAPI.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Keycloak.AuthServices.Authentication;
using FrontEndAPI.Infrastructure.Commands;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Host.UseSerilog((context, configuration) => {
    configuration.WriteTo.Console();
});

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<LabArquiteturaDbContext>(options =>
{
    options.UseInMemoryDatabase("LabArquitetura");
}, ServiceLifetime.Singleton);

builder.Services.AddCors(options =>
{
    options.AddPolicy("allowall", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "http://localhost:4200/", "*");
        policy.AllowAnyHeader();
        policy.AllowCredentials();
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

// Authentication & Authorization
builder.Services.AddKeycloakAuthentication(builder.Configuration);

// Inject dependencies
/// ver: [Diretrizes de injeção de dependência](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection-guidelines)
builder.Services.AddScoped<IOnboardingApplication, OnboardingApplication>();
builder.Services.AddScoped<IOutraConsultaApplication, OutraConsultaApplication>();
builder.Services.AddScoped<IEMailService, EMailService>();
builder.Services.AddScoped<IFolhaService, FolhaService>();
builder.Services.AddScoped<IMaquinaQuery, MaquinaQuery>();
builder.Services.AddScoped<IUsuarioQuery, UsuarioQuery>();
builder.Services.AddSingleton<IFuncionarioCommand, FuncionarioCommand>();
builder.Services.AddSingleton<IFuncionarioQuery, FuncionarioQuery>();

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
