using FrontEndAPI.Core.Application;
using FrontEndAPI.Core.Interfaces;
using FrontEndAPI.Infrastructure.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inject dependencies
/// ver: [Diretrizes de injeção de dependência](https://learn.microsoft.com/pt-br/dotnet/core/extensions/dependency-injection-guidelines)
builder.Services.AddSingleton<IConsultaApplication, ConsultaApplication>();
builder.Services.AddSingleton<IOutraConsultaApplication, OutraConsultaApplication>();
builder.Services.AddSingleton<IEntidadeQuery, EntidadeQuery>();

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

app.Run();
