using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using TaskManagmentSystem.Repository;
using TaskManagmentSystem.Models;
using TaskManagmentSystem.ViewModels;


namespace TaskManagmentSystem
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
        /*    services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;*/
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<TaskManagmentContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TaskManagmentSystemContext")));
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            services.AddScoped< TasksRepository >();
            services.AddScoped<CategoriesRepository>();
            services.AddScoped<TasksCategoriesRepository>();
            
            services.AddControllers();
           /* services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod().AllowCredentials());

            });*/


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            /*services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyMethod()
                  
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyHeader()
                                                         
                                  );
            });*/

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //app.UseCors("CorsPolicy");
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
          
            /* app.UseSpa(spa =>
             {
                 // To learn more about options for serving an Angular SPA from ASP.NET Core,
                 // see https://go.microsoft.com/fwlink/?linkid=864501

                 spa.Options.SourcePath = "ClientApp";

                 if (env.IsDevelopment())
                 {
                     spa.UseAngularCliServer(npmScript: "start");
                 }
             });*/
        }
    }
}
