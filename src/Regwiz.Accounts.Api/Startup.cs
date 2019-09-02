using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Regwiz.Accounts.Business.Infrastructure;
using Regwiz.Accounts.Business.Infrastructure.Command;
using Regwiz.Accounts.Business.Infrastructure.Query;
using Regwiz.Accounts.Dal.Dto;
using Regwiz.Accounts.Dal.Repository;
using Regwiz.Accounts.Dal.Repository.Memory;

namespace Regwiz.Accounts.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services
            //    .AddDbContext<RegwizContext>(options =>
            //    {
            //        options.UseInMemoryDatabase(Guid.NewGuid().ToString());
            //        options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //        options.EnableSensitiveDataLogging();
            //    }, ServiceLifetime.Transient)
            //    .AddSingleton<ICountryRepository, CountryRepository>()
            //    .AddSingleton<IProvinceRepository, ProvinceRepository>()
            //    .AddSingleton<IUserRepository, UserRepository>()
            //    .AddSingleton<IRepository<Country>, CountryRepository>()// more generic than ICountryRepository
            //    .AddSingleton<IRepository<Province>, ProvinceRepository>()
            //    .AddSingleton<IRepository<User>, UserRepository>()
            //    .AddSingleton<IQueryHandler<FindUsersBySearchTextQuery, User[]>, UserQueryHandler>()
            //    .AddSingleton<ICommandHandler<CreateUser>, UserCommandHandler>()
            //    .AddSingleton<ICommandDispatcher, CommandDispatcher>()
            //    .AddSingleton<IQueryDispatcher, QueryDispatcher>()
                ;
            new Regwiz.Accounts.Business.Startup().ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
