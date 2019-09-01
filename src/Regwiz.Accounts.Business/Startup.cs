using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Business.Infrastructure;
using Regwiz.Accounts.Business.Infrastructure.Command;
using Regwiz.Accounts.Business.Infrastructure.Query;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;
using Regwiz.Accounts.Dal.Repository.Memory;

namespace Regwiz.Accounts.Business
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<RegwizContext>(options =>
                {
                    options.UseInMemoryDatabase(Guid.NewGuid().ToString());
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    options.EnableSensitiveDataLogging();
                }, ServiceLifetime.Transient)
                .AddSingleton<ICountryRepository, CountryRepository>()
                .AddSingleton<IProvinceRepository, ProvinceRepository>()
                .AddSingleton<IUserRepository, UserRepository>()
                .AddSingleton<IQueryHandler<FindUsersBySearchTextQuery, User[]>, UserQueryHandler>()
                .AddSingleton<ICommandHandler<CreateUser>, UserCommandHandler>()
                .AddSingleton<ICommandDispatcher, CommandDispatcher>()
                .AddSingleton<IQueryDispatcher, QueryDispatcher>()
                ;
        }
    }
}