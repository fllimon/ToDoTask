using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using ToDoApi.Validator;
using Domain.Interfaces;
using ToDo.EFDatabase.Repositories;
using TextFileDatabase.Repositories;
using ToDo.EFDatabase.Factoryes;
using TextFileDatabase.Factoryes;

namespace ToDoApi
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
            if (ConfigurationValue(Configuration))
            {
                services.AddScoped<IToDoCrud, ToDoCrudDatabase>();
                services.AddSingleton<IToDoFactory, ToDoEfFactory>();
            }
            else
            {
                services.AddScoped<IToDoCrud, ToDoCrudJson>();
                services.AddSingleton<IToDoFactory, ToDoJsonFactory>();
            }

            services.AddControllers()
                .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDoApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDoApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private bool ConfigurationValue(IConfiguration config)
        {
            bool result = bool.Parse(config["ProjectConfiguration:UseDatabase"]);

            return result;
        }
    }
}
