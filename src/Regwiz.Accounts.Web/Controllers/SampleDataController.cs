using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Regwiz.Accounts.Business.Infrastructure;
using Regwiz.Accounts.Business.Infrastructure.Query;

namespace Regwiz.Accounts.Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        ICommandDispatcher _commandDispatcher;
        IQueryDispatcher _queryDispatcher;

        public SampleDataController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        //private static string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //[HttpGet("[action]")]
        //public IEnumerable<WeatherForecast> WeatherForecasts()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    });
        //}

        [HttpGet("[action]")]
        public IEnumerable<Country> Countries()
        {
            //return Enumerable.Range(1, 5).Select(index => new Country
            //{
            //    Name = "asd",
            //    Id = 1
            //});

            var r = _queryDispatcher.Execute<FindCountriesBySearchTextQuery,Dal.Dto.Country[]>(new FindCountriesBySearchTextQuery("", false));
            return r.Select(x=> new Country(){Id = x.Id,Name = x.Name});
        }

        public class Country 
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
