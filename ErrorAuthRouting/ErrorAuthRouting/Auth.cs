using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace ErrorAuthRouting
{
    public class Auth
    {
        private RequestDelegate _next;
        public Auth(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if (token != "10")
            {
                context.Response.StatusCode = 403;
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
}