using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebAPIDemowithEF1.Contracts;
using WebAPIDemowithEF1.Entities;
using WebAPIDemowithEF1.Repositories;
/// <summary>
/// Depolyed on Local IIS
/// http://localhost:7456/API/Students/GetStudents
/// About CORS: https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1
/// </summary>
namespace WebAPIDemowithEF1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //To add repositories to services (Bring this repository to ASP.NET Core Container)
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LearningDBContext>(options => options.UseSqlServer(connection));
            services.AddControllers();

            //Added Configuration to access as a services - To access values from appsettings.json file
            //Reference: https://www.c-sharpcorner.com/article/setting-and-reading-values-from-app-settings-json-in-net-core/
            //services.AddSingleton<IConfiguration>(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
           
            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
