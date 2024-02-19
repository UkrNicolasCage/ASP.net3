using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WebApplication3.Interfaces;
using WebApplication3.Services;

namespace WebApplication3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddTransient<ITimeOfDayService, TimeOfDayService>();

            //services.AddTransient<CalcService>();
            services.AddScoped<CalcService>();
            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.Use(async (context, next) => {
                context.Response.ContentType = "text/plain; charset=utf-8";
                await next();
            });

            app.UseMiddleware<CustomTimeMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
