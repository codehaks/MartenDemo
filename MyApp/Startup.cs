using Marten;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            var options = new StoreOptions();
            options.Connection(connectionString);      
            options.AutoCreateSchemaObjects = AutoCreate.All;

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
