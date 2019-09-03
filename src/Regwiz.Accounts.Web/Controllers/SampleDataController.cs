using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        [HttpGet("[action]")]
        public IEnumerable<Province> Provinces( int countryId)
        {
            Debugger.Break();
            List<Dal.Dto.Province> r = new List<Dal.Dto.Province>();
            r = _queryDispatcher.Execute<FindProvincesByCountryQuery, Dal.Dto.Province[]>(new FindProvincesByCountryQuery(countryId, false)).ToList();
            //r.Add(new Dal.Dto.Province(1, countryId, "asd") );
            return r.Select(x => new Province() { Id = x.Id, Name = x.Name, CountryId = x.Id });

            //so the request comes with correct Id, need to polish dispatcher
            //return Enumerable.Range(1, 5).Select(x=>new Province() {Name = ""+ countryId +"-"+x,Id = x,CountryId = countryId});
        }

        public class Province
        {
            public int Id { get; set; }
            public int CountryId { get; set; }
            public string Name { get; set; }
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
