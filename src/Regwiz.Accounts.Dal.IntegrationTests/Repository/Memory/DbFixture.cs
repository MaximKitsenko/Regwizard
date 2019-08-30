using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Dal.IntegrationTests.Utils.Random;
using Regwiz.Accounts.Dal.Repository;
using Regwiz.Accounts.Dal.Repository.Memory;

namespace Regwiz.Accounts.Dal.IntegrationTests.Repository.Memory
{
    public class DbFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public DbFixture()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                //.AddLogging()
                .AddDbContext<RegwizContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    options.EnableSensitiveDataLogging();
                },ServiceLifetime.Transient)
                .AddSingleton<IRandomGenerator, SimpleRandomGenerator>()
                .AddTransient<ICountryRepository, CountryRepository>()
                .AddSingleton<IUserRepository, UserRepository>()
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