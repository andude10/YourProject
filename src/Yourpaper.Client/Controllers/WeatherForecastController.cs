using Microsoft.AspNetCore.Mvc;
using Yourpaper.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace Yourpaper.Client.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
