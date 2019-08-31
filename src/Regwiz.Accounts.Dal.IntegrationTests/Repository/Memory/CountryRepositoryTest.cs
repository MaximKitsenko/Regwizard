using System;
using System.Collections.Generic;
using System.Linq;
using bonanza.utils.core.IEnumerable;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;
using Regwiz.Accounts.Dal.Repository.Memory;
using Xunit;

namespace Regwiz.Accounts.Dal.IntegrationTests.Repository.Memory
{
    public class CountryRepositoryTest : RepositoryTestBase
    {
        /// <summary>
        /// The constructor will be called before each test [fact]
        /// </summary>
        /// <param name="fixture"></param>
        public CountryRepositoryTest(DbFixture fixture)
        {
            // fact setup
            _serviceProvider = fixture.ServiceProvider;
        }


        [Fact]
        public void ThereIsNoSuchCountry_CreateCountry_CountryCreated()
        {
            //a
            var repository = _serviceProvider.GetService<ICountryRepository>();
            var country = new Country() {Name = "France"};

            //a
            repository.CreateCountrys(country);

            //a
            var countries = repository.ReadAllCountrys().ToListOrAsList();
            countries.Should().NotBeNullOrEmpty();
            countries.Should().Contain(x => x.Name == country.Name);
        }

        [Fact]
        public void ThereIsSuchCountry_UpdateCountry_CountryCreated()
        {
            //a
            int[] countriesCreatedIds;
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                var country = new Country() { Name = "France" };
                var countriesCreated = repository.CreateCountrys(country);
                countriesCreatedIds = countriesCreated.Select(x => x.Id).ToArray();
            }

            //a
            List<Country> countriesForUpdate;
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                countriesForUpdate = repository.ReadCountrys(countriesCreatedIds).ToListOrAsList();
                countriesForUpdate.ForEach(x => x.Name += "100500");
                repository.UpdateCountrys(countriesForUpdate.ToArray());
            }

            //a
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                var countriesAfterUpdate = repository.ReadCountrys(countriesCreatedIds).ToListOrAsList();
                countriesAfterUpdate.Should().NotBeNullOrEmpty();
                countriesAfterUpdate.Should().BeEquivalentTo(countriesForUpdate, options => options.WithoutStrictOrdering());
            }
        }

        [Fact]
        public void ThereIsSuchCountry_DeleteCountry_Deleted()
        {
            //a
            Country country;
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                country = new Country() {Name = "France"};
                repository.CreateCountrys(country);
            }

            //a
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                repository.DeleteCountrys(country);
            }

            //a
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                var countries = repository.ReadAllCountrys().ToListOrAsList();
                countries.Should().NotContain(x => x.Name == country.Name);
            }
        }
    }
}