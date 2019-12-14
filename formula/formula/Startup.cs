using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace formula
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            int a = 5;
            int b = 8;
            int c = 3;
            int x = 6;
            double res = 0;
            app.Use(async (context, next) =>
            {
                res = (1 / a + 1 / b + 1 / c) / (a + Math.Pow(Math.Sin(x), 2.0));
                await next.Invoke();
            });
 
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"(1 / a + 1 / b + 1 / c) / (a + sin^2(x) = " +
                                                  $"(1 / {a} + 1 / {b} + 1 / {c}) / ({a} + sin^2({x}) = {res}" );
            });
        }
    }
}