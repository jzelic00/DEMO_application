using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SMS_Application.DBContext;
using SMS_Application.IO;
using SMS_Application.IO.Interface;
using SMS_Application.Mapper;
using SMS_Application.Midlleware;
using SMS_Application.Repository;
using SMS_Application.Repository.Interface;
using SMS_Application.Services;
using SMS_Application.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMS_Application
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
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                ); ;

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            });

            services.AddCors();

            services.AddRazorPages();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //Mapper 
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProfileMapper());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            //DI services
            services.AddSingleton(mapper);

            services.AddScoped<IContactRepositoryAsync, ContactRepository>();
            services.AddScoped<IMessageRepositoryAsync, MessageRepository>();
            services.AddScoped<IService, Service>();
            services.AddScoped<IFileHandler, TextFileService>();
            services.AddScoped<IInputOutputAsync, InputOutputOperations>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod()
                     .AllowAnyHeader());

                if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            
            app.UseCors(builder => builder.WithOrigins("*")
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseAuthorization();

            app.UseMiddleware<ApiKeyMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
