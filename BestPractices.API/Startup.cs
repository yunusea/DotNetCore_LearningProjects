using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BestPractices.API.Extensions;
using BestPractices.API.Services;
using FluentValidation;
using BestPractices.API.Models;
using BestPractices.API.Validations;
using FluentValidation.AspNetCore;

namespace BestPractices.API
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

            services.AddControllers()
                .AddFluentValidation(x => x.RunDefaultMvcValidationAfterFluentValidationExecutes = false); //MVC Defalt Validation Close
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BestPractices.API", Version = "v1" });
            });

            //Add to Healthcheck service
            services.AddHealthChecks();

            //Add to AutoMapper Service Extension
            services.ConfigureMapping();

            //Add FluentValidator for "MemberDVO"
            services.AddTransient<IValidator<MemberDVO>, MemberValidator>();

            services.AddScoped<IMemberService, MemberService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BestPractices.API v1"));
            }

            //Custom HealthCheck Configure File include in project
            app.UseCustomHealthCheck();

            //DotNet Core Response Caching activated in Project
            app.UseResponseCaching();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
