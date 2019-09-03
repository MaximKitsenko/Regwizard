using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Business.Infrastructure;
using Regwiz.Accounts.Business.Infrastructure.Command;
using Regwiz.Accounts.Business.Infrastructure.Command.Handlers;
using Regwiz.Accounts.Business.Infrastructure.Query;
using Regwiz.Accounts.Business.Infrastructure.Query.Handlers;
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
                }, ServiceLifetime.Singleton)
                .AddSingleton<ICountryRepository, CountryRepository>()
                .AddSingleton<IProvinceRepository, ProvinceRepository>()
                .AddSingleton<IUserRepository, UserRepository>()
                //.AddSingleton<IRepository<Country>, CountryRepository>()// more generic than ICountryRepository
                //.AddSingleton<IRepository<Province>, ProvinceRepository>()
                //.AddSingleton<IRepository<User>, UserRepository>()
                .AddSingleton<IQueryHandler<FindUsersBySearchTextQuery, User[]>, UserQueryHandler>()
                .AddSingleton<IQueryHandler<FindCountriesBySearchTextQuery, Country[]>, CountryQueryHandler>()
                .AddSingleton<IQueryHandler<FindProvincesBySearchTextQuery, Province[]>, ProvinceQueryHandler2>()
                .AddSingleton<IQueryHandler<FindProvincesByCountryQuery, Province[]>, ProvinceQueryHandler>()
                .AddSingleton<ICommandHandler<CreateUser>, UserCommandHandler>()
                .AddSingleton<ICommandHandler<CreateCountry>, CountryCommandHandler>()
                .AddSingleton<ICommandHandler<CreateProvince>, ProvinceCommandHandler>()
                .AddSingleton<ICommandDispatcher, CommandDispatcher>()
                .AddSingleton<IQueryDispatcher, QueryDispatcher>()
                ;
        }
    }
}