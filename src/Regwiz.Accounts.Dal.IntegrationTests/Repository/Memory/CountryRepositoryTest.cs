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
            var country = new Country(0, "France");

            //a
            repository.Create(country);

            //a
            var countries = repository.ReadAll().ToListOrAsList();
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
                var country = new Country(0, "France");
                var countriesCreated = repository.Create(country);
                countriesCreatedIds = countriesCreated.Select(x => x.Id).ToArray();
            }

            //a
            List<Country> countriesForUpdate;
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                countriesForUpdate = repository.Read(countriesCreatedIds).ToListOrAsList();
                countriesForUpdate.ForEach(x => x.Name += "100500");
                repository.Update(countriesForUpdate.ToArray());
            }

            //a
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                var countriesAfterUpdate = repository.Read(countriesCreatedIds).ToListOrAsList();
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
                country = new Country(0, "France");
                repository.Create(country);
            }

            //a
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                repository.Delete(country);
            }

            //a
            using (var repository = _serviceProvider.GetService<ICountryRepository>())
            {
                var countries = repository.ReadAll().ToListOrAsList();
                countries.Should().NotContain(x => x.Name == country.Name);
            }
        }
    }
}