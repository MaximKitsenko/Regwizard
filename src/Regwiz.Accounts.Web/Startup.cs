using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Regwiz.Accounts.Business.Infrastructure;
using Regwiz.Accounts.Business.Infrastructure.Command;
using Regwiz.Accounts.Business.Infrastructure.Query;
using Regwiz.Accounts.Dal.Dto;

namespace Regwiz.Accounts.Web
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

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            new Business.Startup().ConfigureServices(services);



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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            //init
            var cd = app.ApplicationServices.GetService<ICommandDispatcher>();
            var qd = app.ApplicationServices.GetService<IQueryDispatcher>();
            var createCountries = new CreateCountry[]
            {
                new CreateCountry(Guid.NewGuid(), "Rus"),
                new CreateCountry(Guid.NewGuid(), "Usa"),
                new CreateCountry(Guid.NewGuid(), "Ger")
            }.ToList();

            createCountries.ForEach(x=> cd.Execute(x));

            Country[] countries = null;

            for (int i = 0; i < 10; i++)//todo replace to retry
            {
                countries = qd.Execute<FindCountriesBySearchTextQuery, Country[]>(new FindCountriesBySearchTextQuery("", false));
                if (countries.Length == 3)
                {
                    break;
                }

                Task.Delay(100).Wait();
            }


            var createProvince = new List<CreateProvince>();

            foreach (var country in countries)
            {
                for (int i = 0; i < 3; i++)
                {
                    cd.Execute( new CreateProvince(Guid.Empty, country.Id,country.Name+"-Province-"+i));
                }
            }

            //

        }
    }
}
