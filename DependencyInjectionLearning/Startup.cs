using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionLearning
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

            services.AddControllers();

            services.AddTransient<IRandomValueGenerator, RandomValueGenerator>();
            //Request geldiðinde bir kere create ediyor bir instance oluþturuyor. Ayný request içerisinde tekrar ayný instance'ý kullanýyor.
            services.AddScoped<IRandomValueGenerator2, RandomValueGenerator2>();

            //Her kullanýldýðý noktada -ayný request içerisinde olsa dahi -- yeniden create edilip farklý instance oluþturuluyor.
            //services.AddTransient<IRandomValueGenerator, RandomValueGenerator>();

            //Uygulamanýn ömrü boyunca nesne bir kere create edilip sürekli ayný instance kullanýlýyor.
            //services.AddSingleton<IRandomValueGenerator, RandomValueGenerator>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DependencyInjectionLearning", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DependencyInjectionLearning v1"));
            }

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
