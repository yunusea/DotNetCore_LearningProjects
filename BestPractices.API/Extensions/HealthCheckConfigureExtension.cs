using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;

namespace BestPractices.API.Extensions
{
    public static class HealthCheckConfigureExtension
    {
        public static IApplicationBuilder UseCustomHealthCheck(this IApplicationBuilder app)
        {
            //Here create a fake api url for Healthcheck and return "OK"
            app.UseHealthChecks("/api/health", new HealthCheckOptions()
            {
                ResponseWriter = async (context, report) =>
                {
                    await context.Response.WriteAsync("OK");
                }
            });

            return app;
        }
    }
}
