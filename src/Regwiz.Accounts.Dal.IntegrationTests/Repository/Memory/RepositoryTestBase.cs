using System;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Dal.Repository.Memory;
using Xunit;

namespace Regwiz.Accounts.Dal.IntegrationTests.Repository.Memory
{
    /// <summary>
    /// Tests can't be run in parallel within one class.
    /// Classes can be run in parallel
    /// </summary>
    public class RepositoryTestBase: IClassFixture<DbFixture>, IDisposable
    {
        protected ServiceProvider _serviceProvider;

        /// <summary>
        /// Dispose will be called after each test [fact]
        /// </summary>
        public void Dispose()
        {
            var dbContext = _serviceProvider.GetService<RegwizContext>();
            dbContext.Database.EnsureDeleted(); // this will clean the db after each test
        }
    }
}