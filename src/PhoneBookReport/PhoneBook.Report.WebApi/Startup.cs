using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PhoneBook.Report.Business.Abstract;
using PhoneBook.Report.Business.Concrete;
using PhoneBook.Report.WebApi.BackgroundServices;
using PhoneBook.Report.WebApi.Extensions;
using PhoneBook.Report.WebApi.Middlewares;
using System.Text.Json.Serialization;

namespace PhoneBook.Report.WebApi
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
            services.AddControllersWithViews().AddJsonOptions(option =>
          option.JsonSerializerOptions.ReferenceHandler = option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.AddHostedService<ConsumerRabbitMQBackground>();
            services.AddScoped<ILocationReportService, LocationReportManager>();
            services.ConfigureMapping();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.Report.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook.Report.WebApi v1"));
            }

            //app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
