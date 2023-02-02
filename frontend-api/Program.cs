using FrontEndAPI.Core.Application;
using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Infrastructure.Queries;
using FrontEndAPI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "API Lab Arquitetura 2023",
        Version = "v1"
    });
    // config.ResolveConflictingActions(x => x.First());
    // config.IncludeXmlComments()
});

// Inject dependencies
/// ver: [Diretrizes de injeção de dependência](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection-guidelines)
builder.Services.AddSingleton<IConsultaApplication, ConsultaApplication>();
builder.Services.AddSingleton<IOutraConsultaApplication, OutraConsultaApplication>();
builder.Services.AddSingleton<IEntidadeQuery, EntidadeQuery>();

builder.Services.AddSingleton<IEMailService, EMailService>();
builder.Services.AddSingleton<IFolhaService, FolhaService>();
builder.Services.AddSingleton<IMaquinaQuery, MaquinaQuery>();
builder.Services.AddSingleton<IUsuarioQuery, UsuarioQuery>();
builder.Services.AddSingleton<IFuncionarioQuery, FuncionarioQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default", pattern: "{Controller=Home}/{action=Index}/{id?}");

app.Run();
