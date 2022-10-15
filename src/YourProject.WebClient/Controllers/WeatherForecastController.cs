using Microsoft.AspNetCore.Mvc;
using YourProject.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace YourProject.WebClient.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
