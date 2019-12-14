using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ErrorAuthRouting
{
    public class Routing
    {
        private readonly RequestDelegate _next;

        public Routing(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string path = context.Request.Path.Value.ToLower();
            if (path == "/first")
            {
                int a = 5;
                int b = 8;
                int c = 3;
                int x = 6;
                double res = 0;
                res = (1 / a + 1 / b + 1 / c) / (a + Math.Pow(Math.Sin(x), 2.0));
                await context.Response.WriteAsync("First\n");
                await context.Response.WriteAsync($"(1 / a + 1 / b + 1 / c) / (a + sin^2(x) = " +
                                                  $"(1 / {a} + 1 / {b} + 1 / {c}) / ({a} + sin^2({x}) = {res}");
            }
            else if (path == "/second")
            {
                int a = 5;
                int b = 8;
                int c = 3;
                int x = 6;
                double res = 0;
                res = (a + b + c) / x;
                await context.Response.WriteAsync("Second\n");
                await context.Response.WriteAsync($"(a+b+c)/x " + $"({a}+{b}+{c})/{x} = {res}");
            }
            else
            {
                context.Response.StatusCode = 404;
            }

            //await _next.Invoke(context);
        }
    }
}