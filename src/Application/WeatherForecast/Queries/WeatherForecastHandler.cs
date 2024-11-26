using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Application.WeatherForecast.Queries
{
    public class WeatherForecastHandler : IRequestHandler<WeatherForecastQuery, IEnumerable<WeatherForecastDto>>
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public async Task<IEnumerable<WeatherForecastDto>> Handle(WeatherForecastQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToArray();
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}