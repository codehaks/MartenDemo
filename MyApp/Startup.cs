using Marten;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Data;
using System;

namespace MyApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var options = BuildStoreOptions();

            services.AddMarten(options);

            services.AddControllers();

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

        }



        private StoreOptions BuildStoreOptions()
        {
            var connectionString = Configuration.GetConnectionString("Marten");

            // Or lastly, build a StoreOptions object yourself
            var options = new StoreOptions();
            options.Connection(connectionString);

            // Use the more permissive schema auto create behavior
            // while in development
            //  if (Hosting.IsDevelopment())
            //{
            options.AutoCreateSchemaObjects = AutoCreate.All;
            //}

            return options;
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

            });
        }
    }
}
