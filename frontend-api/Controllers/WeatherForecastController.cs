using FrontEndAPI.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace frontend_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOutraConsultaApplication _consultaApplication;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IOutraConsultaApplication consultaApplication)
    {
        _logger = logger;
        _consultaApplication = consultaApplication;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            Ok = this._consultaApplication.Test(12)
        })
        .ToArray();
    }
}
