using System.Linq;
using bonanza.utils.core.IEnumerable;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.IntegrationTests.Utils.Random;
using Regwiz.Accounts.Dal.Repository;
using Regwiz.Accounts.Dal.Repository.Memory;
using Xunit;

namespace Regwiz.Accounts.Dal.IntegrationTests.Repository.Memory
{
    public class CountryRepositoryTest : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;

        public CountryRepositoryTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void ThereIsNoSuchCountry_CreateCountry_CountryCreated()
        {
            //a
            var Repository = _serviceProvider.GetService<ICountryRepository>();
            var country = new Country() {Name = "France"};

            //a
            Repository.CreateCountrys(country);

            //a
            var countries = Repository.ReadAllCountrys().ToListOrAsList();
            countries.Should().NotBeNullOrEmpty();
            countries.Should().Contain(x => x.Name == country.Name);
        }

        //[Fact]
        //public void ThereIsSuchCountry_UpdateCountry_CountryCreated()
        //{
        //    //a
        //    var country = new Country() {Name = "France"};
        //    var countriesCreated = Repository.CreateCountrys(country);
        //    var countriesCreatedIds = countriesCreated.Select(x => x.Id).ToArray();

        //    //a
        //    var countriesForUpdate = Repository.ReadCountrys(countriesCreatedIds).ToListOrAsList();
        //    countriesForUpdate.ForEach(x => x.Name += "100500");
        //    Repository.UpdateCountrys(countriesForUpdate.ToArray());

        //    //a
        //    var countriesAfterUpdate = Repository.ReadCountrys(countriesCreatedIds).ToListOrAsList();
        //    countriesAfterUpdate.Should().NotBeNullOrEmpty();
        //    countriesAfterUpdate.Should().BeEquivalentTo(countriesForUpdate);
        //}

        //[Fact]
        //public void ThereIsSuchCountry_DeleteCountry_Deleted()
        //{
        //    //a
        //    var country = new Country() {Name = "France"};
        //    Repository.CreateCountrys(country);

        //    //a
        //    Repository.DeleteCountrys(country);

        //    //a
        //    var countries = Repository.ReadAllCountrys().ToListOrAsList();
        //    countries.Should().NotContain(x => x.Name == country.Name);
        //}
    }

    public class DbFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        //public TestBase(
        //    IRandomGenerator randomGenerator
        //)
        //{
        //    this.RandomGenerator = randomGenerator;
        //}

        public DbFixture()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
            //.AddLogging()
                    .AddDbContext<RegwizContext>(options => options.UseInMemoryDatabase("db1"),
                        ServiceLifetime.Transient)
                .AddSingleton<IRandomGenerator, SimpleRandomGenerator>()
                .AddSingleton<ICountryRepository, CountryRepository>()
                .AddSingleton<IRandomGenerator, SimpleRandomGenerator>()
                //.AddSingleton<IBarService, BarService>()
                .BuildServiceProvider();

            //configure console logging
            //serviceProvider
            //    .GetService<ILoggerFactory>()
            //    .AddConsole(LogLevel.Debug);

            //var logger = serviceProvider.GetService<ILoggerFactory>()
            //    .CreateLogger<Program>();
            //logger.LogDebug("Starting application");

            //do the actual work here
            //var bar = serviceProvider.GetService<IBarService>();
            //bar.DoSomeRealWork();

            //logger.LogDebug("All done!");
            ServiceProvider = serviceProvider;
        }
    }
}