using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using QuotesRestAPI.Service;
using QuotesRestAPI.Service.Implementation;

namespace QuotesRestAPI
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
            services.AddControllers();

            //Hangfire
            services.AddHangfire(config =>
            config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170).
            UseSimpleAssemblyNameTypeSerializer().
            UseDefaultTypeSerializer()
            .UseMemoryStorage());

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            services.AddSingleton<IDataStorage, DataStorage>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //HangFire dashboard: I used this to check the worker. To open the hangfire dashbor go to https://your_localhot/hangfire
            app.UseHangfireDashboard();
            app.UseHangfireServer();

            //calling worker every 5 minutes 
            RecurringJob.AddOrUpdate<IDataStorage>(
            dataStorage => dataStorage.Worker(),
            Cron.MinuteInterval(5));

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quote API");
            });
        }
    }
}
