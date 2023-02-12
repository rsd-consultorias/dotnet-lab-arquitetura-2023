using FolhaService.Services;
using FolhaWorker;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<ServiceStatus>();

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5097, o => o.Protocols = Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<FolhaService.Services.FolhaService>();
app.MapGet("/", () => "gRPC service...");

app.Run();
