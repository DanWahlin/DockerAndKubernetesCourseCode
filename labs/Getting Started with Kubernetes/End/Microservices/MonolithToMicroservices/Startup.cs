using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using System.IO;
using MonolithToMicroservices.Repository;
using MonolithToMicroservices.Infrastructure;
using MonolithToMicroservices.Models;

namespace MonolithToMicroservices
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

            services.AddMvc();

            services.AddOptions(); //Add ability to inject IOptions<T> for config data
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddSingleton<IHttpClient, StandardHttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //https://github.com/aspnet/JavaScriptServices/blob/dev/samples/angular/MusicStore/Startup.cs
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });

            });
        }
    }
}
