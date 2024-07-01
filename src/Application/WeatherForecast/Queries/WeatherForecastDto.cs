using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WeatherForecast.Queries
{
    public class WeatherForecastDto
    {
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}